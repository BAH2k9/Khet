using Khet3.Enums;
using KhetV3.Enums;
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
    public class LaserViewModel : Screen
    {
        private (double Width, double Height) controlSize;

        private BindableCollection<double> _width = [0, 0, 0, 0];
        public BindableCollection<double> width { get => _width; set => SetAndNotify(ref _width, value); }

        private BindableCollection<double> _height = [0, 0, 0, 0];
        public BindableCollection<double> height { get => _height; set => SetAndNotify(ref _height, value); }

        private BindableCollection<Brush> _fill = [Brushes.Transparent,Brushes.Transparent,
                                                     Brushes.Transparent, Brushes.Transparent];
        public BindableCollection<Brush> fill { get => _fill; set => SetAndNotify(ref _fill, value); }

        public LaserViewModel((LaserPosition, LaserPosition) laserPositions)
        {
            FillLaser(laserPositions.Item1);
            FillLaser(laserPositions.Item2);
        }
        public void OnLoaded()
        {
            if (this.View is FrameworkElement view)
            {
                controlSize.Width = view.ActualWidth;
                controlSize.Height = view.ActualHeight;
            }

            RenderLaser();
        }

        public void OnSizeChanged(SizeChangedEventArgs e)
        {
            // Update properties when the control size changes
            controlSize.Width = e.NewSize.Width;
            controlSize.Height = e.NewSize.Height;

            RenderLaser();
        }

        public void RenderLaser()
        {
            // Top laser
            height[0] = controlSize.Height / 2;
            width[0] = (int)CalculateRatio() * 5;

            // Bottom Laser
            height[1] = controlSize.Height / 2;
            width[1] = (int)CalculateRatio() * 5;

            // Left Laser
            height[2] = (int)CalculateRatio() * 5;
            width[2] = controlSize.Width / 2;

            // Right laser
            height[3] = (int)CalculateRatio() * 5;
            width[3] = controlSize.Width / 2;
        }

        private double CalculateRatio()
        {
            if (controlSize.Height == 0)
                return 0;

            return Math.Abs(controlSize.Width / controlSize.Height);
        }

        public void FillLaser(LaserPosition laserPosition)
        {
            fill[(int)laserPosition] = Brushes.Red;
        }

        public void ClearLaser()
        {
            fill[0] = Brushes.Transparent;
            fill[1] = Brushes.Transparent;
            fill[2] = Brushes.Transparent;
            fill[3] = Brushes.Transparent;
        }
    }
}
