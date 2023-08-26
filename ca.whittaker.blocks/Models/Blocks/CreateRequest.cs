namespace ca.whittaker.blocks.Models.Blocks;

using System.ComponentModel.DataAnnotations;
using System.Data;
using ca.whittaker.blocks.Entities;

public class CreateRequest
{
    [Required]
    public string? Name { get; set; }

    [Required]
    [EnumDataType(typeof(ca.whittaker.BuildingBlocks.IBlock.BlockType))]
    public string? Type { get; set; }

}
