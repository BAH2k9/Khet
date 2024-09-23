using Khet.Stylet.MVVM.Models.MyPieces.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Khet.Stylet.MVVM.Models.MyPieces
{
    public class Pyramid : Piece
    {
        public Pyramid(int player, (int x, int y) position, Orientations orientation)
            : base(player, position, orientation)
        {
        }

        public override Orientations Rotation(Rotate rotation)
        {
            var maxEnumValue = (Orientation)Enum.GetValues(typeof(Orientation)).Length - 1;

            switch (rotation)
            {
                case Rotate.Left:
                    if (orientation == 0)
                    {
                        orientation = maxEnumValue;
                    }
                    else
                    {
                        orientation--;
                        orientation--;
                    }

                    return orientation;
                case Rotate.Right:
                    if (orientation == maxEnumValue)
                    {
                        orientation = 0;
                    }
                    else
                    {
                        orientation++;
                        orientation++;
                    }
                    return orientation;
            }
            return orientation;
        }
    }
}
