using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Khet.Wpf.ViewModels
{
    public class PyramidViewModel : ViewModelBase, IPiece
    {

        private string _rotationAngle = "0";
        public string rotationAngle { get => _rotationAngle; set => SetProperty(ref _rotationAngle, value); }

        public Pyramid orientation { get; set; }

        public PyramidViewModel(Pyramid orientation)
        {
            this.orientation = orientation;
            SetDisplay();
        }

        private void SetDisplay()
        {
            switch(this.orientation)
            {
                case Pyramid.tl:
                    rotationAngle = "0"; 
                    break;
                case Pyramid.tr:
                    rotationAngle = "90";
                    break;
                case Pyramid.bl:
                    rotationAngle = "270";
                    break;
                case Pyramid.br:
                    rotationAngle = "180";
                    break;
            }
        }

        public Direction ResolveLaserDirection(Direction inDirection)
        {
            switch (this.orientation)
            {
                case Pyramid.tl:
                    if (inDirection == Direction.right)
                    {
                        return Direction.down;
                    }
                    else if(inDirection == Direction.down)
                    {
                        return Direction.right;
                    }
                    break;

                case Pyramid.tr:
                    if (inDirection == Direction.left)
                    {
                        return Direction.down;
                    }
                    else if(inDirection == Direction.up)
                    {
                        return Direction.left;
                    }
                    break;

                case Pyramid.bl:
                    if (inDirection == Direction.right)
                    {
                        return Direction.down;
                    }
                    else if (inDirection == Direction.up)
                    {
                        return Direction.right;
                    }
                    break;

                case Pyramid.br:
                    if (inDirection == Direction.left)
                    {
                        return Direction.up;
                    }
                    else if (inDirection == Direction.up)
                    {
                        return Direction.left;
                    }
                    break;
            }

            return Direction.kill;
        }
    }
}
