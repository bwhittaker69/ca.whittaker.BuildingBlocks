namespace ca.whittaker.blocks.Repositories;

using ca.whittaker.blocks.Helpers;
using Dapper;
using ca.whittaker.blocks.Entities;

public interface IBlockRepository
{
    Task<IEnumerable<Block>> GetAll();
    Task<Block> GetById(int id);
    //Task<Block> GetByEmail(string email);
    Task Create(Block user);
    Task Update(Block user);
    Task Delete(int id);
}

public class BlockRepository : IBlockRepository
{
    private DataContext _context;

    public BlockRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Block>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Blocks
        """;
        return await connection.QueryAsync<Block>(sql);
    }

    public async Task<Block> GetById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Blocks 
            WHERE Id = @id
        """;
        return await connection.QuerySingleOrDefaultAsync<Block>(sql, new { id });
    }

    //public async Task<Block> GetByEmail(string email)
    //{
    //    using var connection = _context.CreateConnection();
    //    var sql = """
    //        SELECT * FROM Users 
    //        WHERE Email = @email
    //    """;
    //    return await connection.QuerySingleOrDefaultAsync<Block>(sql, new { email });
    //}

    public async Task Create(Block user)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            INSERT INTO Blocks (Title, FirstName, LastName, Email, Role, PasswordHash)
            VALUES (@Title, @FirstName, @LastName, @Email, @Role, @PasswordHash)
        """;
        await connection.ExecuteAsync(sql, user);
    }

    public async Task Update(Block user)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            UPDATE Blocks 
            SET Title = @Title,
                FirstName = @FirstName,
                LastName = @LastName, 
                Email = @Email, 
                Role = @Role, 
                PasswordHash = @PasswordHash
            WHERE Id = @Id
        """;
        await connection.ExecuteAsync(sql, user);
    }

    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            DELETE FROM Blocks 
            WHERE Id = @id
        """;
        await connection.ExecuteAsync(sql, new { id });
    }
}