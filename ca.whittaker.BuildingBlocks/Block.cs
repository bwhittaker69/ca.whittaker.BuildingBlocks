using System.Drawing;

namespace ca.whittaker.BuildingBlocks
{
    public class Block : IBlock
    {   
        public IBlock.BlockType Type { get; set; }
        public required string Name { get; set; }
        public required long Id { get; set; }
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }
        public int BorderThickness { get; set; }
        public int Padding { get; set; }
        public int Margin { get; set; }
        public Color ForegroundColor { get; set; }
    }
}