using ca.whittaker.blocks.Helpers;
using System.Text.Json.Serialization;
using ca.whittaker.blocks.Repositories;
using ca.whittaker.blocks.Services;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole(); // Add console logging

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddCors();
    services.AddControllers().AddJsonOptions(x =>
    {
        // serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        // ignore omitted parameters on models to enable optional params (e.g. User update)
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // configure strongly typed settings object
    services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

    // configure DI for application services
    services.AddSingleton<DataContext>();
    services.AddScoped<IBlockRepository, BlockRepository>();
    services.AddScoped<IBlockService, BlockService>();
    services.AddScoped<IBlockTypeRepository, BlockTypeRepository>();
    services.AddScoped<IBlockTypeService, BlockTypeService>();
}

var app = builder.Build();

// ensure database and tables exist
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    await context.Init();
}

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.MapControllers();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
