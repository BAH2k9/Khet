using Khet3.Enums;
using KhetV3.Enums;
using KhetV3.MVVM.Models;
using Stylet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace KhetV3.MVVM.ViewModels
{
    public class LaserViewModel : Screen
    {
        public BindableCollection<Brush> fill { get; set; } = [Brushes.Transparent, Brushes.Transparent, Brushes.Transparent, Brushes.Transparent];

        private LaserCoordinates _topLaser;
        public LaserCoordinates topLaser { get => _topLaser; set => SetAndNotify(ref _topLaser, value); }

        private LaserCoordinates _bottomLaser;
        public LaserCoordinates bottomLaser { get => _bottomLaser; set => SetAndNotify(ref _bottomLaser, value); }

        private LaserCoordinates _leftLaser;
        public LaserCoordinates leftLaser { get => _leftLaser; set => SetAndNotify(ref _leftLaser, value); }

        private LaserCoordinates _rightLaser;
        public LaserCoordinates rightLaser { get => _rightLaser; set => SetAndNotify(ref _rightLaser, value); }

        private (LaserPosition, LaserPosition) _laserPositions;
        private (double width, double height) controlSize;
        private (double width, double height) center;
        private int Delay = 50;
        private double moveSpeed;
        private TaskCompletionSource<bool> _loadedCompletionSource = new TaskCompletionSource<bool>();

        public LaserViewModel((LaserPosition, LaserPosition) laserPositions)
        {
            _laserPositions = laserPositions;

            FillLaser(_laserPositions.Item1);
            FillLaser(_laserPositions.Item2);


        }

        public void OnLoaded()
        {
            if (this.View is FrameworkElement view)
            {
                UpdateControlSizes(view.ActualWidth, view.ActualHeight);

                _loadedCompletionSource.SetResult(true);
            }

        }

        public void OnSizeChanged(SizeChangedEventArgs e)
        {
            if (topLaser != null)
            {
                RenderToNewSize(topLaser, e);
            }
            if (bottomLaser != null)
            {
                RenderToNewSize(bottomLaser, e);
            }
            if (leftLaser != null)
            {
                RenderToNewSize(leftLaser, e);
            }
            if (rightLaser != null)
            {
                RenderToNewSize(rightLaser, e);
            }

            UpdateControlSizes(e.NewSize.Width, e.NewSize.Height);
        }

        public void UpdateControlSizes(double newControlWidth, double newControlheight)
        {
            controlSize.width = newControlWidth;
            controlSize.height = newControlheight;

            center.width = newControlWidth / 2;
            center.height = newControlheight / 2;

            moveSpeed = controlSize.width / 5;

        }

        private void RenderToNewSize(LaserCoordinates newPosition, SizeChangedEventArgs e)
        {
            var widthScale = e.NewSize.Width / controlSize.width;
            var heightScale = e.NewSize.Height / controlSize.height;

            newPosition.x1 = newPosition.x1 * widthScale;
            newPosition.x2 = newPosition.x2 * widthScale;
            newPosition.y1 = newPosition.y1 * heightScale;
            newPosition.y2 = newPosition.y2 * heightScale;
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

        public async Task Animate()
        {
            await _loadedCompletionSource.Task;
            await AnimateFirstLaser(_laserPositions.Item1);
            await AnimateSecondLaser(_laserPositions.Item2);
        }

        private async Task AnimateFirstLaser(LaserPosition laserPosition)
        {

            switch (laserPosition)
            {
                case LaserPosition.Top:
                    topLaser = new LaserCoordinates()
                    {
                        x1 = center.width,
                        y1 = 0,
                        x2 = center.width,
                        y2 = 0,
                    };

                    while (topLaser.y2 < center.height) // Adjust to screen height
                    {
                        topLaser.y2 += moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

                case LaserPosition.Bottom:
                    bottomLaser = new LaserCoordinates()
                    {
                        x1 = center.width,
                        y1 = controlSize.height,
                        x2 = center.width,
                        y2 = controlSize.height,
                    };

                    while (bottomLaser.y2 > center.height) // Adjust to screen height
                    {
                        bottomLaser.y2 -= moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

                case LaserPosition.Left:
                    leftLaser = new LaserCoordinates()
                    {
                        x1 = 0,
                        y1 = center.height,
                        x2 = 0,
                        y2 = center.height,
                    };

                    while (leftLaser.x2 < center.width) // Adjust to screen height
                    {
                        leftLaser.x2 += moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

                case LaserPosition.Right:
                    rightLaser = new LaserCoordinates()
                    {
                        x1 = controlSize.width,
                        y1 = center.height,
                        x2 = controlSize.width,
                        y2 = center.height,
                    };

                    while (rightLaser.x2 > center.width) // Adjust to screen height
                    {
                        rightLaser.x2 -= moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

            }

        }

        private async Task AnimateSecondLaser(LaserPosition laserPosition)
        {
            var centerStart = new LaserCoordinates()
            {
                x1 = center.width,
                y1 = center.height,
                x2 = center.width,
                y2 = center.height,
            };

            switch (laserPosition)
            {
                case LaserPosition.Top:
                    topLaser = centerStart;

                    while (topLaser.y2 > 0) // Adjust to screen height
                    {
                        topLaser.y2 -= moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

                case LaserPosition.Bottom:
                    bottomLaser = centerStart;

                    while (bottomLaser.y2 < controlSize.height) // Adjust to screen height
                    {
                        bottomLaser.y2 += moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

                case LaserPosition.Left:
                    leftLaser = centerStart;

                    while (leftLaser.x2 > 0) // Adjust to screen height
                    {
                        leftLaser.x2 -= moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

                case LaserPosition.Right:
                    rightLaser = centerStart;

                    while (rightLaser.x2 < controlSize.width) // Adjust to screen height
                    {
                        rightLaser.x2 += moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

            }
        }

        public async void AnimateRemoveLaser()
        {

            switch (_laserPositions.Item1)
            {
                case LaserPosition.Top:

                    while (topLaser.y1 < center.height) // Adjust to screen height
                    {
                        topLaser.y1 += moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

                case LaserPosition.Bottom:

                    while (bottomLaser.y1 > center.height) // Adjust to screen height
                    {
                        bottomLaser.y1 -= moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

                case LaserPosition.Left:

                    while (leftLaser.x1 < center.width) // Adjust to screen height
                    {
                        leftLaser.x1 += moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

                case LaserPosition.Right:

                    while (rightLaser.x1 > center.width) // Adjust to screen height
                    {
                        rightLaser.x1 -= moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

            }


            switch (_laserPositions.Item2)
            {
                case LaserPosition.Top:
                    while (topLaser.y1 > 0) // Adjust to screen height
                    {
                        topLaser.y1 -= moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

                case LaserPosition.Bottom:
                    while (bottomLaser.y1 < controlSize.height) // Adjust to screen height
                    {
                        bottomLaser.y1 += moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

                case LaserPosition.Left:
                    while (leftLaser.x1 > 0) // Adjust to screen height
                    {
                        leftLaser.x1 -= moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

                case LaserPosition.Right:
                    while (rightLaser.x1 < controlSize.width) // Adjust to screen height
                    {
                        rightLaser.x1 += moveSpeed;
                        await Task.Delay(this.Delay);
                    }
                    break;

            }
        }



    }
}
