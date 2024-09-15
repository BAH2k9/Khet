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

        private Brush _background;
        public Brush Background { get => _background; set => SetProperty(ref _background, value); }

        public bool IsSelected { get; set; } = false;

        public int positionX { get; }

        public int positionY {  get; }

        public SquareViewModel(int positionX, int positionY)
        {
            selectColor = Brushes.Black;
            Background = Brushes.Transparent;
            this.positionX = positionX;
            this.positionY = positionY;
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
                this.IsSelected = true;
                selectColor = Brushes.LawnGreen;
            }
            else
            {
                this.IsSelected = false;
                selectColor = Brushes.Black;
            }
            
        }

        public void movePiece(SquareViewModel nextSquare)
        {
          
             activePiece?.MovePiece(this, nextSquare);
           

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

        public void SetSquareColor(int player)
        {
            if (player == 1)
            {
                this.Background = Brushes.LightGray;
            }
            else if (player == 2)
            {
                this.Background = Brushes.IndianRed;

            }

        }
    }
}
