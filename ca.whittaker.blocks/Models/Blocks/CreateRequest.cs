namespace ca.whittaker.blocks.Models.Blocks;

using System.ComponentModel.DataAnnotations;
using System.Data;
using ca.whittaker.blocks.Entities;
using ca.whittaker.buildingblocks.Models;

public class CreateRequest
{
    [Required]
    public string? Name { get; set; }

    [Required]
    [EnumDataType(typeof(IBlock.BlockType))]
    public string? Type { get; set; }

}
