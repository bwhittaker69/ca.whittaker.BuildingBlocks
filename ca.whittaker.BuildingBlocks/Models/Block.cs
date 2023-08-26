using ca.whittaker.buildingblocks.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ca.whittaker.bulidingblocks.Models
{
    [Table("blocks", Schema = "buildingblocks")]
    public partial class Block : IEntity
    {
        [Key]
        [Column("id")] // Map to "id" column in the database
        public long Id { get; set; }

        [Required]
        [Column("name")] // Map to "name" column in the database
        public string Name { get; set; }

        [Column("domain")] // Map to "domain" column in the database
        public string Domain { get; set; }

        [Required]
        [Column("description")] // Map to "description" column in the database
        public string Description { get; set; }

        [Column("icon")] // Map to "icon" column in the database
        public byte[] Icon { get; set; }

        [Column("blocktypeid")] // Map to "blocktypeid" column in the database
        public long? BlockTypeId { get; set; }

        [Column("backgroundcolor")] // Map to "backgroundcolor" column in the database
        [RegularExpression("^#[a-f0-9]{6}$")]
        public string BackgroundColor { get; set; }

        [Column("bordercolor")] // Map to "bordercolor" column in the database
        [RegularExpression("^#[a-f0-9]{6}$")]
        public string BorderColor { get; set; }

        [Column("fontcolor")] // Map to "fontcolor" column in the database
        [RegularExpression("^#[a-f0-9]{6}$")]
        public string FontColor { get; set; }

        [Column("border")] // Map to "border" column in the database
        public int? Border { get; set; }

        [Column("margin")] // Map to "margin" column in the database
        public int? Margin { get; set; }

        [Column("parentblockid")] // Map to "parentblockid" column in the database
        public long? ParentBlockId { get; set; }

        [Column("childblockid")] // Map to "childblockid" column in the database
        public long? ChildBlockId { get; set; }

        [ForeignKey("BlockTypeId")]
        public virtual BlockType BlockType { get; set; }

        [ForeignKey("ParentBlockId")]
        public virtual Block ParentBlock { get; set; }

        [ForeignKey("ChildBlockId")]
        public virtual Block ChildBlock { get; set; }
    }
}
