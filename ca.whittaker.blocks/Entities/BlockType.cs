using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ca.whittaker.buildingblocks;

namespace ca.whittaker.blocks.Entities
{
    [Table("blocktypes", Schema = "buildingblocks")]
    public class BlockType : ca.whittaker.buildingblocks.Models.BlockType
    {
  
    }
}
