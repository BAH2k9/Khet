using Khet2._0.MVVM.ViewModel;

namespace Khet2._0.Events
{
    public class PieceMovedEvent
    {
        public int player { get; set; }
        public SquareViewModel oldSquare { get; set; }
        public SquareViewModel newSquare { get; set; }
        public PieceMovedEvent(int player, SquareViewModel oldSquare, SquareViewModel newSquare)
        {
            this.player = player;
            this.oldSquare = oldSquare;
            this.newSquare = newSquare;
        }


    }
}