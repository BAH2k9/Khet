using Khet2._0.Enums;

namespace Khet2._0.Interfaces
{
    public interface IPiece
    {
        public Orientations orientation { get; set; }

        public int player { get; set; }
        public void RenderPiece();
    }
}