using Khet3.Enums;
using KhetV3.Interfaces;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace KhetV3.MVVM.ViewModels
{
    public class DjedViewModel : Screen, IRotatable
    {
        public Orientations orientation { get; set; }

        private (double width, double height) controlSize;

        private Brush _playerColor;
        public Brush playerColor { get => _playerColor; set => SetAndNotify(ref _playerColor, value); }

        public BindableCollection<double> point1 { get; set; } = [0, 0];
        public BindableCollection<double> point2 { get; set; } = [0, 0];
        public int player { get; set; }

        public DjedViewModel(Orientations orientation, int player)
        {
            this.player = player;
            this.orientation = orientation;

            SetColor();
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
            if (this.orientation == Orientations.NE || this.orientation == Orientations.SW)
            {
                point1[0] = 0;
                point1[1] = 0;
                point2[0] = controlSize.width;
                point2[1] = controlSize.height;
            }
            else
            {
                point1[0] = controlSize.width;
                point1[1] = 0;
                point2[0] = 0;
                point2[1] = controlSize.height;
            }

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


    }
}
