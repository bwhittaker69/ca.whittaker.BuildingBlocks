namespace ca.whittaker.blocks.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ca.whittaker.blocks.Models.BlockTypes;
    using ca.whittaker.blocks.Services;

    [ApiController]
    [Route("[controller]")]
    public class BlockTypesController : ControllerBase
    {
        private IBlockTypeService _blockTypeService;

        public BlockTypesController(IBlockTypeService blockTypeService)
        {
            _blockTypeService = blockTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blockTypes = await _blockTypeService.GetAll();
            return Ok(blockTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blockType = await _blockTypeService.GetById(id);
            return Ok(blockType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlockTypeRequest blockType)
        {
            await _blockTypeService.Create(blockType);
            return Ok(new { message = "BlockType created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBlockTypeRequest blockType)
        {
            await _blockTypeService.Update(id, blockType);
            return Ok(new { message = "BlockType updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blockTypeService.Delete(id);
            return Ok(new { message = "BlockType deleted" });
        }
    }
}
