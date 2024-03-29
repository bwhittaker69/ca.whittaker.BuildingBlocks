﻿namespace ca.whittaker.blocks.Controllers;

using Microsoft.AspNetCore.Mvc;
using ca.whittaker.blocks.Models.Blocks;
using ca.whittaker.blocks.Services;

[ApiController]
[Route("[controller]")]
public partial class BlocksController : ControllerBase
{
    private IBlockService _blockService;

    public BlocksController(IBlockService blockService)
    {
        _blockService = blockService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var blocks = await _blockService.GetAll();
        return Ok(blocks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var block = await _blockService.GetById(id);
        return Ok(block);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBlockRequest block)
    {
        await _blockService.Create(block);
        return Ok(new { message = "block created" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateBlockRequest block)
    {
        await _blockService.Update(id, block);
        return Ok(new { message = "block updated" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _blockService.Delete(id);
        return Ok(new { message = "block deleted" });
    }
}