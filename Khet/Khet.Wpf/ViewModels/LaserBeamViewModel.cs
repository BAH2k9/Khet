using Khet.Wpf.Core;
using Khet.Wpf.Enums;
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

        private List<string> _height;
        public List<string> height { get => _height; set => SetProperty(ref _height, value); }
       
        private List<string >_width;
        public List<string> width { get => _width; set => SetProperty(ref _width, value); }

        private List<string> _horizontalAlignment;
        public List<string> horizontalAlignment { get => _horizontalAlignment; set => SetProperty(ref _horizontalAlignment, value); }

        private List<string> _verticalAlignment;
        public List<string> verticalAlignment { get => _verticalAlignment; set => SetProperty(ref _verticalAlignment, value); }


        public LaserBeamViewModel(Direction direction, PieceViewModel piece)
        {

            if (direction == Direction.up)
            {
                width = new List<string> { "10", "0" };
                height = new List<string> { "100", "0" };
                if (piece?.orientation == OrientationDjed.dl)
                {
                    width = new List<string> { "10", "50" };
                    height = new List<string> { "50", "10" };
                    horizontalAlignment = new List<string> { "Center", "Right" };
                    verticalAlignment = new List<string> { "Top", "Center" };
                }

                if (piece?.orientation == OrientationDjed.dr)
                {
                    width = new List<string> { "10", "50" };
                    height = new List<string> { "50", "10" };
                    horizontalAlignment = new List<string> { "Center", "Left" };
                    verticalAlignment = new List<string> { "Top", "Center" };
                }

            }

            if (direction == Direction.down)
            {
                width = new List<string> { "10", "0" };
                height = new List<string> { "100", "0" };

                if (piece?.orientation == OrientationDjed.dl)
                {
                    width = new List<string> { "10", "50" };
                    height = new List<string> { "50", "10" };
                    horizontalAlignment = new List<string> { "Center", "Left" };
                    verticalAlignment = new List<string> { "bottom", "Center" };
                }

                if (piece?.orientation == OrientationDjed.dr)
                {
                    width = new List<string> { "10", "50" };
                    height = new List<string> { "50", "10" };
                    horizontalAlignment = new List<string> { "Center", "right" };
                    verticalAlignment = new List<string> { "bottom", "Center" };
                }

            }

            if (direction == Direction.left)
            {
                width = new List<string> { "100", "0" };
                height = new List<string> { "10", "0" };
                if (piece?.orientation == OrientationDjed.dl)
                {
                    width = new List<string> { "50", "10" };
                    height = new List<string> { "10", "50" };
                    horizontalAlignment = new List<string> { "Left", "Center" };
                    verticalAlignment = new List<string> { "Center", "Bottom" };
                }

                if (piece?.orientation == OrientationDjed.dr)
                {
                    width = new List<string> { "50", "10" };
                    height = new List<string> { "10", "50" };
                    horizontalAlignment = new List<string> { "Left", "Center" };
                    verticalAlignment = new List<string> { "Center", "Top" };
                }

            }

            if (direction == Direction.right)
            {
                width = new List<string> { "100", "0" };
                height = new List<string> { "10", "0" };

                if (piece?.orientation == OrientationDjed.dl)
                {
                    width = new List<string> { "50", "10" };
                    height = new List<string> { "10", "50" };
                    horizontalAlignment = new List<string> { "Right", "Center" };
                    verticalAlignment = new List<string> { "Center", "Top" };
                }

                if (piece?.orientation == OrientationDjed.dr)
                {
                    width = new List<string> { "50", "10" };
                    height = new List<string> { "10", "50" };
                    horizontalAlignment = new List<string> { "Right", "Center" };
                    verticalAlignment = new List<string> { "Center", "Bottom" };
                }

            }

        }
    }
}
