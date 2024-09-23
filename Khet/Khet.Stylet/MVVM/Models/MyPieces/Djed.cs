using System;
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

        public override void Rotate(Rotate rotation)
        {
            var maxEnumValue = (Orientations)System.Enum.GetValues(typeof(Orientations)).Length - 1;

            switch (rotation)
            {
                case Enum.Rotate.Left:
                    if (orientation == 0)
                    {
                        orientation = maxEnumValue;
                    }
                    else
                    {
                        orientation--;
                    }

                    break;
                case Enum.Rotate.Right:
                    if (orientation == maxEnumValue)
                    {
                        orientation = 0;
                    }
                    else
                    {
                        orientation++;
                    }
                    break;

            }

        }



    }



}
