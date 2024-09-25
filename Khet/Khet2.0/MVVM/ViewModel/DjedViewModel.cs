using Khet2._0.Enums;
using Khet2._0.Interfaces;
using Khet2._0.MVVM.Models;
using Stylet;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace Khet2._0.MVVM.ViewModel
{
    public class DjedViewModel : Screen, IPiece
    {
        public Orientations orientation { get; set; }
        private ControlSize controlSize { get; set; } = new ControlSize();

        private Brush _playerColor;
        public Brush playerColor { get => _playerColor; set => SetAndNotify(ref _playerColor, value); }

        public ObservableCollection<double> point1 { get; set; } = [0, 0];
        public ObservableCollection<double> point2 { get; set; } = [0, 0];

        public DjedViewModel(Orientations orientation, int player)
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
            if (this.orientation == Orientations.NE || this.orientation == Orientations.SW)
            {
                point1[0] = 0;
                point1[1] = 0;
                point2[0] = controlSize.Width;
                point2[1] = controlSize.Height;
            }
            else
            {
                point1[0] = controlSize.Width;
                point1[1] = 0;
                point2[0] = 0;
                point2[1] = controlSize.Height;
            }

        }
    }
}
