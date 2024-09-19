using Khet.Wpf.Enums;
using Khet.Wpf.Models;
using Khet.Wpf.ViewModels;

namespace Khet.Wpf.Interfaces
{
    public interface IPiece
    {
        Direction ResolveLaserDirection(Direction direction);

        public void RotatePiece(Rotate rotation);

        public void MovePiece(SquareViewModel previousSquare, SquareViewModel nextSquare);

        public void SetColor(int player);



    }
}
