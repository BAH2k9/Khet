using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Numerics;

namespace Khet.Wpf.ViewModels
{
    public class PyramidViewModel : ViewModelBase, IPiece
    {

        private string _rotationAngle = "0";
        public string rotationAngle { get => _rotationAngle; set => SetProperty(ref _rotationAngle, value); }

        public int player { get; set; }

        private Brush _playerColor;
        public Brush playerColor { get => _playerColor; set => SetProperty(ref _playerColor, value); }

        public Pyramid orientation { get; set; }

        public PyramidViewModel(Pyramid orientation, int player = 1)
        {
            this.player = player;
            this.orientation = orientation;
            SetDisplay();
        }

        private void SetDisplay()
        {
            // Set orientation of piece
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

            if (player == 1)
            {
                playerColor = Brushes.Silver;
            }
            else if (player == 2)
            {
                playerColor = Brushes.Red;
            }
        }

        public Direction ResolveLaserDirection(Direction inDirection)
        {

            var input = Tuple.Create(inDirection, this.orientation);
            var outDirection = Mappings.PyramidDirection[input];
            return outDirection;
           
        }
    }
}
