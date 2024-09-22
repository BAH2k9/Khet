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
        private ObservableCollection<double> _height = [0, 0, 0, 0];
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
            if (_direction == Direction.Up || _direction == Direction.Down)
            {

                FillLaser(Laser.Top);
                FillLaser(Laser.Bottom);
            }

            if (_direction == Direction.Left || _direction == Direction.Right)
            {

                FillLaser(Laser.Left);
                FillLaser(Laser.Right);
            }
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

        private double CalculateRatio()
        {
            if (controlHeight == 0)
                return 0;

            return Math.Abs(controlWidth / controlHeight);
        }

        public void FillLaser(Laser laserPosition)
        {
            fill[(int)laserPosition] = Brushes.Red;
        }


        private void DisplayLaser(PyramidViewModel pyramid)
        {
            switch (_direction)
            {
                case Direction.Up:
                    FillLaser(Laser.Top);
                    if (pyramid.orientation == Pyramid.BL)
                    {
                        FillLaser(Laser.Right);
                    }

                    if (pyramid.orientation == Pyramid.BR)
                    {
                        FillLaser(Laser.Left);
                    }
                    break;

                case Direction.Down:
                    FillLaser(Laser.Bottom);

                    if (pyramid.orientation == Pyramid.TL)
                    {
                        FillLaser(Laser.Right);
                    }

                    if (pyramid.orientation == Pyramid.TR)
                    {
                        FillLaser(Laser.Left);
                    }
                    break;

                case Direction.Left:
                    FillLaser(Laser.Left);
                    if (pyramid.orientation == Pyramid.TR)
                    {
                        FillLaser(Laser.Bottom);
                    }

                    if (pyramid.orientation == Pyramid.BR)
                    {
                        FillLaser(Laser.Top);
                    }
                    break;

                case Direction.Right:
                    FillLaser(Laser.Right);

                    if (pyramid.orientation == Pyramid.TL)
                    {
                        FillLaser(Laser.Bottom);

                    }

                    if (pyramid.orientation == Pyramid.BL)
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
                case Direction.Up:
                    FillLaser(Laser.Top);

                    if (djed.orientation == Djed.DL)
                    {
                        FillLaser(Laser.Right);
                    }

                    if (djed.orientation == Djed.DR)
                    {
                        FillLaser(Laser.Left);
                    }
                    break;

                case Direction.Down:
                    FillLaser(Laser.Bottom);

                    if (djed.orientation == Djed.DL)
                    {
                        FillLaser(Laser.Left);
                    }

                    if (djed.orientation == Djed.DR)
                    {
                        FillLaser(Laser.Right);
                    }
                    break;

                case Direction.Left:
                    FillLaser(Laser.Left);

                    if (djed.orientation == Djed.DL)
                    {
                        FillLaser(Laser.Bottom);
                    }

                    if (djed.orientation == Djed.DR)
                    {
                        FillLaser(Laser.Top);
                    }
                    break;

                case Direction.Right:
                    FillLaser(Laser.Right);

                    if (djed.orientation == Djed.DL)
                    {
                        FillLaser(Laser.Top);
                    }

                    if (djed.orientation == Djed.DR)
                    {
                        FillLaser(Laser.Bottom);
                    }
                    break;
            }
        }
    }


}
