using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Interfaces;
using Khet.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Khet.Wpf.ViewModels
{
    public class SquareViewModel : ViewModelBase
    {

        private IPiece? _activePiece;
        public IPiece? activePiece { get => _activePiece; set => SetProperty(ref _activePiece, value); }

        private ViewModelBase _activeLaser;
        public ViewModelBase activeLaser { get => _activeLaser; set => SetProperty(ref _activeLaser, value); }

        private Brush _selectColor;
        public Brush selectColor { get => _selectColor; set => SetProperty(ref _selectColor, value); }
        public RelayCommand<DragEventArgs> StartDragCommand { get; }

        public SquareViewModel()
        {
            StartDragCommand = new RelayCommand<DragEventArgs>(StartDrag);

            selectColor = Brushes.Black;
        }

        private void StartDrag(DragEventArgs e)
        {
            DragDrop.DoDragDrop(Application.Current.MainWindow, this, DragDropEffects.Move);
        }

        public Direction FireLaser(Direction firingDirection)
        {
            // Get in direction
            var inDirection = getInDirection(firingDirection);

            // Display this sqaures laser
            activeLaser = new LaserBeamViewModel(inDirection, activePiece);

            // Check for active piece
            if (activePiece != null)
            {
                var outDirection = activePiece.ResolveLaserDirection(inDirection);

                if (outDirection == Direction.kill)
                {
                    activePiece = null;
                }

                return outDirection;
                
            }

            return firingDirection;
        }

        public void Select(bool selected)
        {
            if (selected)
            {
                selectColor = Brushes.LawnGreen;
            }
            else
            {
                selectColor = Brushes.Black;
            }
            
        }

        private Direction getInDirection(Direction firingDirection)
        {
            // Look into defining direction.flip 
            switch(firingDirection)
            {
                case Direction.down:
                    return Direction.up;
                case Direction.up:
                    return Direction.down;
                case Direction.left:
                    return Direction.right;
                case Direction.right:
                    return Direction.left;
            }

            return firingDirection; // TODO: think of a better solution here i.e. throw illegal state error

        }

        public void ClearLaser()
        {
            activeLaser = null;

        }

        public void ClearPiece()
        {
            activePiece = null;
        }
    }
}
