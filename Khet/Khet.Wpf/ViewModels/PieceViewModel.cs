using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Wpf.ViewModels
{
    public class PieceViewModel : ViewModelBase
    {
        public OrientationDjed orientation {  get; set; }
        public PieceViewModel()
        {



        }

        public Direction ResolveLaserOutDirection(Direction inDirection)
        {

            switch (this.orientation)
            {
                case OrientationDjed.dl:
                    if (inDirection == Direction.down)
                    {
                        return Direction.left;
                    }
                    else if (inDirection == Direction.right)
                    {
                        return Direction.up;
                    }
                    else if (inDirection == Direction.left)
                    {
                        return Direction.down;
                    }
                    else // (inDirection == Direction.up)
                    {
                        return Direction.right;
                    }

                case OrientationDjed.dr:
                    if (inDirection == Direction.down)
                    {
                        return Direction.left;
                    }
                    else if (inDirection == Direction.right)
                    {
                        return Direction.up;
                    }
                    else if (inDirection == Direction.left)
                    {
                        return Direction.down;
                    }
                    else // (inDirection == Direction.up)
                    {
                        return Direction.right;
                    }                                
            }

            return Direction.kill;

        }
    }
}
