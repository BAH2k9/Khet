using KhetV3.AbstractClasses;
using KhetV3.Interfaces;
using KhetV3.Services;
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
    public class ObeliskViewModel : Piece
    {

        private Brush _playerColor2;
        public Brush playerColor2 { get => _playerColor2; set => SetAndNotify(ref _playerColor2, value); }

        private double _size;
        public double Size { get => _size; set => SetAndNotify(ref _size, value); }

        private (double width, double height) controlSize;

        private ClickService _clickService;

        public int Lives = 2;

        private string _imagePath;
        public string imagePath { get => _imagePath; set => SetAndNotify(ref _imagePath, value); }

        public ObeliskViewModel(ClickService clickService, int player)
        {
            _clickService = clickService;
            this.player = player;
            SetColor(player);

            imagePath = "pack://application:,,,/Assets/Shield-Unbroken.png";

        }
        public void ExecuteMouseDown()
        {
            _clickService.Click(this);
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

        public void Hit()
        {
            Lives--;
            imagePath = "pack://application:,,,/Assets/Shield-Broken.png";
        }

        public override void SetColor(int player)
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
