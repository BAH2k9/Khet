using Khet2._0.MVVM.ViewModel;
using System.Windows.Input;

namespace Khet2._0.Events
{
    public class PieceRotateEvent
    {
        public SquareViewModel square { get; set; }

        public Key key { get; set; }
        public PieceRotateEvent(SquareViewModel square, Key key)
        {
            this.square = square;
            this.key = key;
        }
    }
}