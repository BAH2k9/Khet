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
        }

        public Direction ResolveLaserDirection(Direction inDirection)
        {

            var input = Tuple.Create(inDirection, this.orientation);
            var outDirection = Mappings.PyramidDirection[input];
            return outDirection;
           
        }
    }
}
