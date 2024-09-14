using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Interfaces;
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

        abstract public Direction ResolveLaserDirection(Direction direction);

        virtual public void RotatePiece(Rotate rotation)
        {
            throw new InvalidOperationException("Piece cannot be rotated!");
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
