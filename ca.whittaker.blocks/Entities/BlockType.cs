using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ca.whittaker.buildingblocks.Models; // Import the namespace

namespace ca.whittaker.blocks.Entities
{
    [Table("blocktypes", Schema = "buildingblocks")]
    public class BlockType : ca.whittaker.bulidingblocks.Models.BlockType
    {
        // Additional properties, if needed

        // Navigation property to related blocks
        public virtual ICollection<Block> Blocks { get; set; }
    }
}
