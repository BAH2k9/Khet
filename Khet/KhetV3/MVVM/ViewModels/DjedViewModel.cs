using Khet3.Enums;
using KhetV3.AbstractClasses;
using KhetV3.Interfaces;
using KhetV3.MVVM.Models;
using KhetV3.Services;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace KhetV3.MVVM.ViewModels
{
    public class DjedViewModel : Piece, IRotatable
    {
        public Orientations orientation { get; set; }

        private (double width, double height) controlSize;

        public BindableCollection<double> point1 { get; set; } = [0, 0];
        public BindableCollection<double> point2 { get; set; } = [0, 0];
        private ClickService _clickService;
        public DjedViewModel(ClickService clickService, Orientations orientation, int player)
        {
            _clickService = clickService;
            this.player = player;
            this.orientation = orientation;

            SetColor(player);
        }

        public DjedViewModel(int player, Orientations orientation)
        {
            this.orientation = orientation;
            this.player = player;
            SetColor(player);
            SetOrientation(orientation);
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

        public Orientations Rotate(Key key)
        {
            orientation = DirectionMappings.Rotate[(orientation, key)];

            SetOrientation(orientation);

            _clickService.RotationOccured();

            return orientation;
        }

        public void SetOrientation(Orientations newOrientation)
        {
            orientation = newOrientation;
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
    }
}
