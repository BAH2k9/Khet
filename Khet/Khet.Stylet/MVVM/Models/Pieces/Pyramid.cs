using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Stylet.MVVM.Models.Pieces
{
    public class Pyramid
    {
        public Orientation myOrientation;
        public Pyramid(Orientation orientation)
        {
            myOrientation = orientation;
        }

        public void Rotate(RotateDirection rotateDirection)
        {


            switch (rotateDirection)
            {
                case RotateDirection.CW:
                    RotateClockWise();
                    break;
                case RotateDirection.CCW:
                    RotateCounterClockWise();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RotateClockWise()
        {
            var maxEnumValue = (Orientation)Enum.GetValues(typeof(Orientation)).Length - 1;

            if (myOrientation == maxEnumValue)
            {
                myOrientation = (Orientation)0;
            }
            else
            {
                myOrientation++;
            }

        }

        private void RotateCounterClockWise()
        {
            var maxEnumValue = (Orientation)Enum.GetValues(typeof(Orientation)).Length - 1;


            if (myOrientation == 0)
            {
                myOrientation = maxEnumValue;
            }
            else
            {
                myOrientation--;
            }
        }


    }
}
