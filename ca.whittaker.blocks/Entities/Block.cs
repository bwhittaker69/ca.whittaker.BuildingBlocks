// Entities/Block.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ca.whittaker.blocks.Entities; // Import the necessary namespace
using ca.whittaker.bulidingblocks.Models;

namespace ca.whittaker.blocks.Entities
{
    [Table("blocks", Schema = "buildingblocks")]
    public class Block : ca.whittaker.buildingblocks.Models.Block
    {
        // Additional properties or customizations if needed

        // Navigation properties to related entities
        public virtual BlockType BlockType { get; set; }
        public virtual Block ParentBlock { get; set; }
        public virtual Block ChildBlock { get; set; }
    }
}
