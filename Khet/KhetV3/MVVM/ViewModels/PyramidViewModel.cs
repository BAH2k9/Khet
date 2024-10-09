using Khet3.Enums;
using KhetV3.AbstractClasses;
using KhetV3.Interfaces;
using KhetV3.MVVM.Models;
using KhetV3.Services;
using Stylet;
using Stylet.Xaml;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace KhetV3.MVVM.ViewModels
{
    public class PyramidViewModel : Piece, IRotatable
    {
        private ClickService _clickService;
        public Orientations orientation { get; set; }
        private (double width, double height) controlSize { get; set; }

        private PointCollection _points;
        public PointCollection points { get => _points; set => SetAndNotify(ref _points, value); }

        public PyramidViewModel(ClickService clickService, Orientations orientation, int player)
        {
            _clickService = clickService;
            this.player = player;
            this.orientation = orientation;

            SetColor(player);
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

        public void Rotate(Key key)
        {
            orientation = DirectionMappings.Rotate[(orientation, key)];
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
