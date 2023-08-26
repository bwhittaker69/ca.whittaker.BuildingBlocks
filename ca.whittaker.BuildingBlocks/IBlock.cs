using System.Drawing;

namespace ca.whittaker.BuildingBlocks
{
    public interface IBlock
    {
        public enum BlockType
        {
            LineOfBusiness = 100,
            Enterprise = 200,
            Segment = 300,
            Intiative = 400,
            Architecture = 500,
            Technology = 600,
            Solution  =700
        }
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }
        public int BorderThickness { get; set; }
        public int Padding { get; set; }
        public int Margin { get; set; }
        public Color ForegroundColor { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public BlockType Type { get; set; }
    }
}