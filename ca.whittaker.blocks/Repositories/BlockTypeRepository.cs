namespace ca.whittaker.blocks.Repositories
{
    using ca.whittaker.blocks.Helpers;
    using Dapper;
    using ca.whittaker.blocks.Entities;

    public interface IBlockTypeRepository
    {
        Task<IEnumerable<BlockType>> GetAll();
        Task<BlockType> GetById(int id);
        Task Create(BlockType blockType);
        Task Update(BlockType blockType);
        Task Delete(int id);
    }

    public class BlockTypeRepository : IBlockTypeRepository
    {
        private DataContext _context;

        public BlockTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlockType>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT * FROM buildingblocks.blocktypes
            ";
            return await connection.QueryAsync<BlockType>(sql);
        }

        public async Task<BlockType> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT * FROM buildingblocks.blocktypes 
                WHERE id = @id
            ";
            return await connection.QuerySingleOrDefaultAsync<BlockType>(sql, new { id });
        }

        public async Task Create(BlockType blockType)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                INSERT INTO buildingblocks.blocktypes (name, icon, backgroundcolor, bordercolor, fontcolor, border, margin)
                VALUES (@Name, @Icon, @BackgroundColor, @BorderColor, @FontColor, @Border, @Margin)
            ";
            await connection.ExecuteAsync(sql, blockType);
        }

        public async Task Update(BlockType blockType)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                UPDATE buildingblocks.blocktypes 
                SET name = @Name,
                    icon = @Icon,
                    backgroundcolor = @BackgroundColor,
                    bordercolor = @BorderColor,
                    fontcolor = @FontColor,
                    border = @Border,
                    margin = @Margin
                WHERE id = @Id
            ";
            await connection.ExecuteAsync(sql, blockType);
        }

        public async Task Delete(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                DELETE FROM buildingblocks.blocktypes 
                WHERE id = @id
            ";
            await connection.ExecuteAsync(sql, new { id });
        }
    }
}
