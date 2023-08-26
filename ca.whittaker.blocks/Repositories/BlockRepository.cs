namespace ca.whittaker.blocks.Repositories
{
    using ca.whittaker.blocks.Helpers;
    using Dapper;
    using ca.whittaker.blocks.Entities;

    public interface IBlockRepository
    {
        Task<IEnumerable<Block>> GetAll();
        Task<Block> GetById(int id);
        Task Create(Block thisblock);
        Task Update(Block thisblock);
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
            var sql = @"
                SELECT * FROM buildingblocks.blocks
            ";
            return await connection.QueryAsync<Block>(sql);
        }

        public async Task<Block> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT * FROM buildingblocks.blocks 
                WHERE id = @id
            ";
            return await connection.QuerySingleOrDefaultAsync<Block>(sql, new { id });
        }

        public async Task Create(Block thisblock)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                INSERT INTO buildingblocks.blocks (name, domain, description, icon, blocktypeid, backgroundcolor, bordercolor, fontcolor, border, margin, parentblockid, childblockid)
                VALUES (@Name, @Domain, @Description, @Icon, @BlockTypeId, @BackgroundColor, @BorderColor, @FontColor, @Border, @Margin, @ParentBlockId, @ChildBlockId)
            ";
            await connection.ExecuteAsync(sql, thisblock);
        }

        public async Task Update(Block thisblock)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                UPDATE buildingblocks.blocks 
                SET name = @Name,
                    domain = @Domain,
                    description = @Description,
                    icon = @Icon,
                    blocktypeid = @BlockTypeId,
                    backgroundcolor = @BackgroundColor,
                    bordercolor = @BorderColor,
                    fontcolor = @FontColor,
                    border = @Border,
                    margin = @Margin,
                    parentblockid = @ParentBlockId,
                    childblockid = @ChildBlockId
                WHERE id = @Id
            ";
            await connection.ExecuteAsync(sql, thisblock);
        }

        public async Task Delete(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                DELETE FROM buildingblocks.blocks 
                WHERE id = @id
            ";
            await connection.ExecuteAsync(sql, new { id });
        }
    }
}
