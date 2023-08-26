// Entities/Block.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ca.whittaker.blocks.Entities; // Import the necessary namespace
using ca.whittaker.buildingblocks.Models;

namespace ca.whittaker.blocks.Entities
{
    [Table("blocks", Schema = "buildingblocks")]
    public class Block : ca.whittaker.buildingblocks.Models.Block
    {

    }
}
