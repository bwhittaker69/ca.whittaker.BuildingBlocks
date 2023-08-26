using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ca.whittaker.buildingblocks.Models
{
    [Table("blocktypes", Schema = "buildingblocks")]
    public class BlockType : IEntity
    {
        [Key]
        [Column("id")] // Map to "id" column in the database
        public long Id { get; set; }

        [Required]
        [Column("name")] // Map to "name" column in the database
        public required string Name { get; set; }

        [Column("icon")] // Map to "icon" column in the database
        public byte[]? Icon { get; set; }

        [Column("backgroundcolor")] // Map to "backgroundcolor" column in the database
        [RegularExpression("^#[a-f0-9]{6}$")]
        public string? BackgroundColor { get; set; }

        [Column("bordercolor")] // Map to "bordercolor" column in the database
        [RegularExpression("^#[a-f0-9]{6}$")]
        public string? BorderColor { get; set; }

        [Column("fontcolor")] // Map to "fontcolor" column in the database
        [RegularExpression("^#[a-f0-9]{6}$")]
        public string? FontColor { get; set; }

        [Column("border")] // Map to "border" column in the database
        public int? Border { get; set; }

        [Column("margin")] // Map to "margin" column in the database
        public int? Margin { get; set; }

        [NotMapped]
        public virtual ICollection<Block>? Blocks { get; set; }
    }
}
