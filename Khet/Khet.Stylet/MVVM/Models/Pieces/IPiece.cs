using Khet.Stylet.Enums;

namespace Khet.Stylet.MVVM.Models.Pieces
{
    public interface IPiece
    {
        public Orientation orientation { get; set; }
        public void RotatePiece(RotateDirection direction);
    }
}
