using Khet3.Enums;
using KhetV3.Interfaces;
using Stylet;
using Stylet.Xaml;
using System;
using System.Windows;
using System.Windows.Media;

namespace KhetV3.MVVM.ViewModels
{
    public class PyramidViewModel : Screen, IRotatable
    {
        public Orientations orientation { get; set; }
        private (double width, double height) controlSize { get; set; }

        private Brush _playerColor;
        public Brush playerColor { get => _playerColor; set => SetAndNotify(ref _playerColor, value); }

        private PointCollection _points;
        public PointCollection points { get => _points; set => SetAndNotify(ref _points, value); }

        public int player { get; set; }
        public PyramidViewModel(Orientations orientation, int player)
        {
            this.player = player;
            this.orientation = orientation;

            SetColor();
        }

        private void SetColor()
        {
            if (player == 1)
            {
                playerColor = Brushes.Silver;
            }
            else
            {
                playerColor = Brushes.Red;
            }
        }

        public void OnLoaded()
        {
            if (this.View is FrameworkElement view)
            {
                controlSize = (view.ActualWidth, view.ActualHeight);
            }

            RenderPiece();
        }

        public void OnSizeChanged(SizeChangedEventArgs e)
        {
            controlSize = (e.NewSize.Width, e.NewSize.Height);
            RenderPiece();
        }

        public void Rotate(RotationDirection direction)
        {
            switch (direction)
            {
                case RotationDirection.CCW:
                    orientation = (Orientations)(((int)orientation + 1) % 4);
                    break;
                case RotationDirection.CW:
                    orientation = (Orientations)(((int)orientation + 3) % 4);
                    break;
            }

            RenderPiece();
        }

        public void RenderPiece()
        {
            switch (this.orientation)
            {
                case Orientations.SE:
                    points = new PointCollection
                    {
                        new Point(0,0),
                        new Point(controlSize.width, 0),
                        new Point(0, controlSize.height)
                    };
                    break;
                case Orientations.SW:
                    points = new PointCollection
                    {
                         new Point(0, 0),
                         new Point(controlSize.width, 0),
                         new Point(controlSize.width, controlSize.height)
                    };
                    break;
                case Orientations.NE:
                    points = new PointCollection
                    {
                         new Point(0, 0),
                         new Point(0, controlSize.height),
                         new Point(controlSize.width, controlSize.height)
                    };
                    break;
                case Orientations.NW:

                    points = new PointCollection
                    {
                         new Point(controlSize.width, 0),
                         new Point(0, controlSize.height),
                         new Point(controlSize.width, controlSize.height)
                    };
                    break;
            }
        }



    }
}
