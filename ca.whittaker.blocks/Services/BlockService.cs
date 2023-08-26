namespace ca.whittaker.blocks.Services
{
    using AutoMapper;
    using ca.whittaker.blocks.Helpers;
    using ca.whittaker.blocks.Models.Blocks;
    using ca.whittaker.blocks.Entities;
    using ca.whittaker.blocks.Repositories;

    public interface IBlockService
    {
        Task<IEnumerable<Block>> GetAll();
        Task<Block> GetById(int id);
        Task Create(CreateRequest block);
        Task Update(int id, UpdateRequest updatedBlock);
        Task Delete(int id);
    }

    public class BlockService : IBlockService
    {
        private readonly IBlockRepository _blockRepository;
        private readonly IMapper _mapper;

        public BlockService(
            IBlockRepository blockRepository,
            IMapper mapper)
        {
            _blockRepository = blockRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Block>> GetAll()
        {
            return await _blockRepository.GetAll();
        }

        public async Task<Block> GetById(int id)
        {
            var block = await _blockRepository.GetById(id);

            if (block == null)
                throw new KeyNotFoundException("Block not found");

            return block;
        }

        public async Task Create(CreateRequest block)
        {
            // Map the request data to the Block entity
            var newBlock = _mapper.Map<Block>(block);

            // Save the new block
            await _blockRepository.Create(newBlock);
        }

        public async Task Update(int id, UpdateRequest updatedBlock)
        {
            var existingBlock = await _blockRepository.GetById(id);

            if (existingBlock == null)
                throw new KeyNotFoundException("Block not found");

            // Update the existing block entity with the updatedBlock data
            _mapper.Map(updatedBlock, existingBlock);

            // Save the updated block
            await _blockRepository.Update(existingBlock);
        }

        public async Task Delete(int id)
        {
            await _blockRepository.Delete(id);
        }
    }
}
