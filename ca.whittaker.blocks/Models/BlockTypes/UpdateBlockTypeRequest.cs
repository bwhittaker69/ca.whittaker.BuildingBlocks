using System.ComponentModel.DataAnnotations;

namespace ca.whittaker.blocks.Models.BlockTypes
{
    public class UpdateBlockTypeRequest
    {
        [Required]
        public required string Name { get; set; }

        public byte[]? Icon { get; set; }

        [RegularExpression("^#[a-f0-9]{6}$", ErrorMessage = "Background color must be a valid hex color code.")]
        public string? BackgroundColor { get; set; }

        [RegularExpression("^#[a-f0-9]{6}$", ErrorMessage = "Border color must be a valid hex color code.")]
        public string? BorderColor { get; set; }

        [RegularExpression("^#[a-f0-9]{6}$", ErrorMessage = "Font color must be a valid hex color code.")]
        public string? FontColor { get; set; }

        public int? Border { get; set; }

        public int? Margin { get; set; }
    }
}
