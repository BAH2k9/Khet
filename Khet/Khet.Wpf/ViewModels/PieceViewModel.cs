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

        private string _x1;
        public string x1 { get => _x1; set => SetProperty(ref _x1, value); }

        private string _x2;
        public string x2 { get => _x2; set => SetProperty(ref _x2, value); }

        private string _y1;
        public string y1 { get => _y1; set => SetProperty(ref _y1, value); }

        private string _y2;
        public string y2 { get => _y2; set => SetProperty(ref _y2, value); }


        public PieceViewModel(OrientationDjed orientation)
        {

            this.orientation = orientation;
            SetDisplay();
        }

        private void SetDisplay()
        {
            if (this.orientation == OrientationDjed.dl)
            {
                x1 = "0";
                x2 = "100";
                y1 = "0";
                y2 = "100";

            }
            else
            {
                x1 = "0";
                x2 = "100";
                y1 = "100";
                y2 = "0";
            }


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
                        return Direction.right;
                    }
                    else if (inDirection == Direction.right)
                    {
                        return Direction.down;
                    }
                    else if (inDirection == Direction.left)
                    {
                        return Direction.up;
                    }
                    else // (inDirection == Direction.up)
                    {
                        return Direction.left;
                    }                                
            }

            return Direction.kill;

        }
    }
}
