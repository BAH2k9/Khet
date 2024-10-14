using KhetV3.Interfaces;

namespace KhetV3.MVVM.ViewModels
{
    public class PieceCapturedEvent
    {
        public IPiece Piece { get; set; }
        public PieceCapturedEvent(IPiece piece)
        {
            Piece = piece;
        }
    }
}