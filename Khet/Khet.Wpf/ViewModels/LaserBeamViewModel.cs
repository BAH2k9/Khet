using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Khet.Wpf.ViewModels
{
    class LaserBeamViewModel : ViewModelBase
    {

        private Direction _direction;       

        // Bindable properties
        //private List<string> _height;
        //public List<string> height { get => _height; set => SetProperty(ref _height, value); }
       
        //private List<string >_width;
        //public List<string> width { get => _width; set => SetProperty(ref _width, value); }

        //private List<string> _horizontalAlignment;
        //public List<string> horizontalAlignment { get => _horizontalAlignment; set => SetProperty(ref _horizontalAlignment, value); }

        //private List<string> _verticalAlignment;
        //public List<string> verticalAlignment { get => _verticalAlignment; set => SetProperty(ref _verticalAlignment, value); }

        private List<string> _angle = new List<string> { "0", "0" };
        public List<string> angle { get => _angle; set => SetProperty(ref _angle, value); }



        public LaserBeamViewModel(Direction direction, IPiece piece)
        {
            _direction = direction;

            if (piece is DjedViewModel djed)
            {
                DisplayLaser(djed);
                return;
            }

            if(piece is PyramidViewModel pyramid)
            {
                DisplayLaser(pyramid);
                return;
            }

            DisplayLaser();

        }

        private void DisplayLaser()
        {
            if (_direction == Direction.up || _direction == Direction.down)
            {

                angle[0] = "0";
                angle[1] = "180";
            }

            if (_direction == Direction.left || _direction == Direction.right)
            {

                angle[0] = "90";
                angle[1] = "270";
            }
        }

        private void DisplayLaser(PyramidViewModel pyramid)
        {
            
        }

        private void DisplayLaser(DjedViewModel djed)
        {

            switch (_direction)
            {
                case Direction.up:
                    angle[0] = "0";

                    if (djed.orientation == Djed.dl)
                    {
                        angle[1] = "90";
                    }

                    if (djed.orientation == Djed.dr)
                    {
                        angle[1] = "270";
                    }
                    break;

                case Direction.down:
                    angle[0] = "180";

                    if (djed.orientation == Djed.dl)
                    {
                        angle[1] = "270";
                    }

                    if (djed.orientation == Djed.dr)
                    {
                        angle[1] = "90";
                    }
                    break;

                case Direction.left:
                    angle[0] = "270";

                    if (djed.orientation == Djed.dl)
                    {
                        angle[1] = "180";
                    }

                    if (djed.orientation == Djed.dr)
                    {
                        angle[1] = "0";
                    }
                    break;

                case Direction.right:
                    angle[0] = "90";

                    if (djed.orientation == Djed.dl)
                    {
                        angle[1] = "0";
                    }

                    if (djed.orientation == Djed.dr)
                    {
                        angle[1] = "180";
                    }
                    break;
            }
        }
    }
}
