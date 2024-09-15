using Khet.Wpf.AbstractClasses;
using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Khet.Wpf.ViewModels
{
    public class LaserBeamViewModel : ViewModelBase
    {

        private double _controlWidth;
        public double controlWidth
        {
            get { return _controlWidth; }
            set { _controlWidth = value; UpdateDisplay(); }
        }
        private double _controlHeight { get; set; }
        public double controlHeight
        {
            get { return _controlHeight; }
            set { _controlHeight = value; UpdateDisplay(); }
        }

        private ObservableCollection<double> _width = [0, 0, 0, 0];
        public ObservableCollection<double> width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }
        private ObservableCollection<double> _height = [0,0,0,0];
        public ObservableCollection<double> height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        private ObservableCollection<Brush> _fill = [Brushes.Transparent,
                                                     Brushes.Transparent,
                                                     Brushes.Transparent,
                                                     Brushes.Transparent];
       

        public ObservableCollection<Brush> fill
        {
            get => _fill;
            set => SetProperty(ref _fill, value);
        }

        private Direction _direction;

        public LaserBeamViewModel(Direction direction, IPiece piece, LaserBeamViewModel activeLaser)
        {
            _direction = direction;

            if (activeLaser != null)
            {
                this.height = activeLaser.height;
                this.width = activeLaser.width;
                this.fill = activeLaser.fill;
            }


            if (piece is DjedViewModel djed)
            {
                DisplayLaser(djed);
                return;
            }

            if (piece is PyramidViewModel pyramid)
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

                FillLaser(Laser.Top);
                FillLaser(Laser.Bottom);
            }

            if (_direction == Direction.left || _direction == Direction.right)
            {

                FillLaser(Laser.Left);
                FillLaser(Laser.Right);
            }
        }

        private double CalculateRatio()
        {
            return Math.Abs(controlWidth / controlHeight) ;
        }

        private void UpdateDisplay()
        {
            // Top laser
            height[0] = controlHeight / 2;
            width[0] = (int)CalculateRatio() * 5;

            // Bottom Laser
            height[1] = controlHeight / 2;
            width[1] = (int)CalculateRatio() * 5;

            // Left Laser
            height[2] = (int)CalculateRatio() * 5;
            width[2] = controlWidth / 2;

            // Right laser
            height[3] = (int)CalculateRatio() * 5;
            width[3] = controlWidth / 2;
        }
        public void FillLaser(Laser laserPos)
        {
            fill[(int)laserPos] = Brushes.Red; 
        }


        private void DisplayLaser(PyramidViewModel pyramid)
        {
            switch (_direction)
            {
                case Direction.up:
                    FillLaser(Laser.Top);
                    if (pyramid.orientation == Pyramid.bl)
                    {
                        FillLaser(Laser.Right);
                    }

                    if (pyramid.orientation == Pyramid.br)
                    {
                        FillLaser(Laser.Left);
                    }
                    break;

                case Direction.down:
                    FillLaser(Laser.Bottom);

                    if (pyramid.orientation == Pyramid.tl)
                    {
                        FillLaser(Laser.Right);
                    }

                    if (pyramid.orientation == Pyramid.tr)
                    {
                        FillLaser(Laser.Left);
                    }
                    break;

                case Direction.left:
                    FillLaser(Laser.Left);
                    if (pyramid.orientation == Pyramid.tr)
                    {
                        FillLaser(Laser.Bottom);
                    }

                    if (pyramid.orientation == Pyramid.br)
                    {
                        FillLaser(Laser.Top);
                    }
                    break;

                case Direction.right:
                    FillLaser(Laser.Right);

                    if (pyramid.orientation == Pyramid.tl)
                    {
                        FillLaser(Laser.Bottom);

                    }

                    if (pyramid.orientation == Pyramid.bl)
                    {
                        FillLaser(Laser.Top);

                    }

                    break;
            }
        }


        private void DisplayLaser(DjedViewModel djed)
        {

            switch (_direction)
            {
                case Direction.up:
                    FillLaser(Laser.Top);

                    if (djed.orientation == Djed.dl)
                    {
                        FillLaser(Laser.Right);
                    }

                    if (djed.orientation == Djed.dr)
                    {
                        FillLaser(Laser.Left);
                    }
                    break;

                case Direction.down:
                    FillLaser(Laser.Bottom);

                    if (djed.orientation == Djed.dl)
                    {
                        FillLaser(Laser.Left);
                    }

                    if (djed.orientation == Djed.dr)
                    {
                        FillLaser(Laser.Right);
                    }
                    break;

                case Direction.left:
                    FillLaser(Laser.Left);

                    if (djed.orientation == Djed.dl)
                    {
                        FillLaser(Laser.Bottom);
                    }

                    if (djed.orientation == Djed.dr)
                    {
                        FillLaser(Laser.Top);
                    }
                    break;

                case Direction.right:
                    FillLaser(Laser.Right);

                    if (djed.orientation == Djed.dl)
                    {
                        FillLaser(Laser.Top);
                    }

                    if (djed.orientation == Djed.dr)
                    {
                        FillLaser(Laser.Bottom);
                    }
                    break;
            }
        }





    }


}
