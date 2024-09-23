using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using Khet.Stylet.MVVM.Models.MyPieces.Enum;

namespace Khet.Stylet.MVVM.Models.MyPieces
{
    public class Djed : Piece
    {

        public Djed(int player, (int x, int y) position, Orientations orientation)
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
                    }
                    return orientation;
                    return orientation;
            }
        }



    }



}
