namespace ca.whittaker.blocks.Controllers;

using Microsoft.AspNetCore.Mvc;
using ca.whittaker.blocks.Models.Blocks;
using ca.whittaker.blocks.Services;

[ApiController]
[Route("[controller]")]
public class BlocksController : ControllerBase
{
    private IBlockService _blockService;

    public BlocksController(IBlockService blockService)
    {
        _blockService = blockService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _blockService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _blockService.GetById(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRequest model)
    {
        await _blockService.Create(model);
        return Ok(new { message = "User created" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRequest model)
    {
        await _blockService.Update(id, model);
        return Ok(new { message = "User updated" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _blockService.Delete(id);
        return Ok(new { message = "User deleted" });
    }
}