using Stylet;

namespace KhetV3.Interfaces
{
    public interface IPiece
    {
        public int player { get; set; }
        public (int row, int col) position { get; set; }
        public void SetPosition((int, int) position);
    }
}