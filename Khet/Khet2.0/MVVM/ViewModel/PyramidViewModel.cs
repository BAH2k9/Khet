using Khet2._0.Enums;
using Khet2._0.Interfaces;
using Khet2._0.MVVM.Models;
using Stylet;
using System.Windows;
using System.Windows.Media;

namespace Khet2._0.MVVM.ViewModel
{
    public class PyramidViewModel : Screen, IPiece
    {
        public Orientations orientation { get; set; }
        private ControlSize controlSize { get; set; } = new ControlSize();

        private Brush _playerColor;
        public Brush playerColor { get => _playerColor; set => SetAndNotify(ref _playerColor, value); }

        private PointCollection _points;
        public PointCollection points { get => _points; set => SetAndNotify(ref _points, value); }

        public PyramidViewModel(Orientations orientation, int player)
        {
            this.orientation = orientation;
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
                controlSize.Width = view.ActualWidth;
                controlSize.Height = view.ActualHeight;
            }

            RenderPiece();
        }

        public void OnSizeChanged(SizeChangedEventArgs e)
        {
            // Update properties when the control size changes
            controlSize.Width = e.NewSize.Width;
            controlSize.Height = e.NewSize.Height;

            RenderPiece();
        }

        private void RenderPiece()
        {
            switch (this.orientation)
            {
                case Orientations.SE:
                    points = new PointCollection
                    {
                        new Point(0,0),
                        new Point(controlSize.Width, 0),
                        new Point(0, controlSize.Height)
                    };
                    break;
                case Orientations.SW:
                    points = new PointCollection
                    {
                         new Point(0, 0),
                         new Point(controlSize.Width, 0),
                         new Point(controlSize.Width, controlSize.Height)
                    };
                    break;
                case Orientations.NE:
                    points = new PointCollection
                    {
                         new Point(0, 0),
                         new Point(0, controlSize.Height),
                         new Point(controlSize.Width, controlSize.Height)
                    };
                    break;
                case Orientations.NW:

                    points = new PointCollection
                    {
                         new Point(controlSize.Width, 0),
                         new Point(0, controlSize.Height),
                         new Point(controlSize.Width, controlSize.Height)
                    };
                    break;
            }
        }

    }
}
