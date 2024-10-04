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
    public class ObeliskViewModel : Screen, IPiece
    {
        private Brush _playerColor;
        public Brush playerColor { get => _playerColor; set => SetAndNotify(ref _playerColor, value); }

        private Brush _playerColor2;
        public Brush playerColor2 { get => _playerColor2; set => SetAndNotify(ref _playerColor2, value); }

        private double _size;
        public double Size { get => _size; set => SetAndNotify(ref _size, value); }

        private (double width, double height) controlSize;

        public int player { get; set; }

        public ObeliskViewModel(int player)
        {
            this.player = player;
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
        private void RenderPiece()
        {
            Size = (controlSize.width + controlSize.height) / 10;
        }

        private void SetColor()
        {
            if (player == 1)
            {
                playerColor = Brushes.Silver;
                playerColor2 = new SolidColorBrush(Color.FromArgb(0xFF, 0xb3, 0xb3, 0xb3)); // Darker Silver
            }
            else
            {
                playerColor = Brushes.Red;
                playerColor2 = new SolidColorBrush(Color.FromArgb(0xFF, 0xe6, 0x00, 0x00)); // Darker Red
            }
        }
    }
}
