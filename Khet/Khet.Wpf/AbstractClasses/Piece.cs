using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Exceptions;
using Khet.Wpf.Interfaces;
using Khet.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Khet.Wpf.AbstractClasses
{
    public abstract class Piece : ViewModelBase, IPiece
    {
        protected Brush playerColor = Brushes.Silver;

        virtual public void MovePiece(SquareViewModel previousSquare, SquareViewModel nextSquare)
        {

            var x1 = previousSquare.positionX;
            var x2 = nextSquare.positionX;
            var y1 = previousSquare.positionY;
            var y2 = nextSquare.positionY;

            if(nextSquare.activePiece != null)
            {
                throw new PieceMoveException("Piece cannot be moved there!");

            } else if (Math.Abs(x1 - x2) <= 1 && Math.Abs(y1 - y2) <= 1)
            {
                var temp = previousSquare.activePiece;
                previousSquare.activePiece = null;
                nextSquare.activePiece = temp;
            }
            else throw new PieceMoveException("Piece cannot be moved there!");

        }

        abstract public Direction ResolveLaserDirection(Direction direction);

        virtual public void RotatePiece(Rotate rotation)
        {
            throw new PieceRotationException("Piece cannot be rotated!");
        }

        public void SetColor(int player)
        {
            if (player == 1)
            {
                this.playerColor = Brushes.DarkGray;
            }
            else if (player == 2)
            {
                this.playerColor = Brushes.Red;
            }
        }
    }
}
