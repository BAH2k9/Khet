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
using System.Collections.ObjectModel;

namespace Khet.Wpf.ViewModels
{
    public class PyramidViewModel : ViewModelBase, IPiece
    {

        private string _rotationAngle = "0";
        public string rotationAngle { get => _rotationAngle; set => SetProperty(ref _rotationAngle, value); }

        private List<double> _rotationPoint = [0, 0];
        public List<double> rotationPoint { get => _rotationPoint; set => SetProperty(ref _rotationPoint, value); }


        public int player { get; set; }

        private Brush _playerColor;
        public Brush playerColor { get => _playerColor; set => SetProperty(ref _playerColor, value); }

        public Pyramid orientation { get; set; }

        private double _controlWidth;
        public double controlWidth
        {
            get { return _controlWidth; }
            set { _controlWidth = value; SetOrientation(); }
        }

        private double _controlHeight { get; set; }
        public double controlHeight
        {
            get { return _controlHeight; }
            set { _controlHeight = value;  SetOrientation(); }
        }

        private PointCollection _points;
        public PointCollection points { get => _points; set => SetProperty(ref _points, value); }



        public PyramidViewModel(Pyramid orientation, int player = 1)
        {
            this.player = player;
            this.orientation = orientation;

            SetColor();
            SetOrientation();
        }

        private void SetColor()
        {

            if (player == 1)
            {
                playerColor = Brushes.Silver;
            }
            else if (player == 2)
            {
                playerColor = Brushes.Red;
            }          

        }

        private void SetOrientation()
        {
            switch (this.orientation)
            {
                case Pyramid.tl:
                    points = new PointCollection
                    {
                        new Point(0,0),
                        new Point(controlWidth, 0),
                        new Point(0, controlHeight)
                    };
                    break;
                case Pyramid.tr:
                    points = new PointCollection
                    {
                         new Point(0, 0),
                         new Point(controlWidth, 0),
                         new Point(controlWidth, controlHeight)
                    };
                    break;
                case Pyramid.bl:
                    points = new PointCollection
                    {
                         new Point(0, 0),
                         new Point(0, controlHeight),
                         new Point(controlWidth, controlHeight)
                    };
                    break;
                case Pyramid.br:

                    points = new PointCollection
                    {
                         new Point(controlWidth, 0),
                         new Point(0, controlHeight),
                         new Point(controlWidth, controlHeight)
                    };
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
