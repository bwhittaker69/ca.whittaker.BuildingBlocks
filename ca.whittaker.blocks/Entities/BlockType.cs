﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ca.whittaker.blocks.Entities
{
    [Table("blocktypes", Schema = "buildingblocks")]
    public class BlockType : ca.whittaker.buildingblocks.Models.BlockType
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[] Icon { get; set; }

        [RegularExpression("^#[a-f0-9]{6}$", ErrorMessage = "Background color must be a valid hex color code.")]
        public string BackgroundColor { get; set; }

        [RegularExpression("^#[a-f0-9]{6}$", ErrorMessage = "Border color must be a valid hex color code.")]
        public string BorderColor { get; set; }

        [RegularExpression("^#[a-f0-9]{6}$", ErrorMessage = "Font color must be a valid hex color code.")]
        public string FontColor { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Border value must be a non-negative integer.")]
        public int? Border { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Margin value must be a non-negative integer.")]
        public int? Margin { get; set; }
    }
}
