using System.ComponentModel.DataAnnotations;

namespace ca.whittaker.blocks.Models.Blocks
{
    public class CreateBlockRequest
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Domain { get; set; }

        [Required]
        public required string Description { get; set; }

        public byte[]? Icon { get; set; }

        [Required]
        public long BlockTypeId { get; set; }

        [RegularExpression("^#[a-f0-9]{6}$", ErrorMessage = "Background color must be a valid hex color code.")]
        public string? BackgroundColor { get; set; }

        [RegularExpression("^#[a-f0-9]{6}$", ErrorMessage = "Border color must be a valid hex color code.")]
        public string? BorderColor { get; set; }

        [RegularExpression("^#[a-f0-9]{6}$", ErrorMessage = "Font color must be a valid hex color code.")]
        public string? FontColor { get; set; }

        public int? Border { get; set; }

        public int? Margin { get; set; }

        public long? ParentBlockId { get; set; }

        public long? ChildBlockId { get; set; }
    }
}
