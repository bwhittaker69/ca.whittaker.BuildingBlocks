namespace ca.whittaker.blocks.Services
{
    using AutoMapper;
    using ca.whittaker.blocks.Helpers;
    using ca.whittaker.blocks.Models.BlockTypes;
    using ca.whittaker.blocks.Entities;
    using ca.whittaker.blocks.Repositories;

    public interface IBlockTypeService
    {
        Task<IEnumerable<BlockType>> GetAll();
        Task<BlockType> GetById(int id);
        Task Create(CreateBlockTypeRequest blockType);
        Task Update(int id, UpdateBlockTypeRequest updatedBlockType);
        Task Delete(int id);
    }

    public class BlockTypeService : IBlockTypeService
    {
        private readonly IBlockTypeRepository _blockTypeRepository;
        private readonly IMapper _mapper;

        public BlockTypeService(
            IBlockTypeRepository blockTypeRepository,
            IMapper mapper)
        {
            _blockTypeRepository = blockTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BlockType>> GetAll()
        {
            return await _blockTypeRepository.GetAll();
        }

        public async Task<BlockType> GetById(int id)
        {
            var blockType = await _blockTypeRepository.GetById(id);

            if (blockType == null)
                throw new KeyNotFoundException("BlockType not found");

            return blockType;
        }

        public async Task Create(CreateBlockTypeRequest blockType)
        {
            // Map the request data to the BlockType entity
            var newBlockType = _mapper.Map<BlockType>(blockType);

            // Save the new block type
            await _blockTypeRepository.Create(newBlockType);
        }

        public async Task Update(int id, UpdateBlockTypeRequest updatedBlockType)
        {
            var existingBlockType = await _blockTypeRepository.GetById(id);

            if (existingBlockType == null)
                throw new KeyNotFoundException("BlockType not found");

            // Update the existing block type entity with the updatedBlockType data
            _mapper.Map(updatedBlockType, existingBlockType);

            // Save the updated block type
            await _blockTypeRepository.Update(existingBlockType);
        }

        public async Task Delete(int id)
        {
            await _blockTypeRepository.Delete(id);
        }
    }
}
