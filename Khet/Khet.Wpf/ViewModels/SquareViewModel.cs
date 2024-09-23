using Khet.Wpf.AbstractClasses;
using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Interfaces;
using Khet.Wpf.Models;
using System.Windows;
using System.Windows.Media;

namespace Khet.Wpf.ViewModels
{
    public class SquareViewModel : ViewModelBase
    {
        private IPiece? _activePiece;
        public IPiece? activePiece
        {
            get => _activePiece;
            set => SetProperty(ref _activePiece, value);
        }

        private LaserBeamViewModel _activeLaser;
        public LaserBeamViewModel activeLaser
        {
            get => _activeLaser;
            set => SetProperty(ref _activeLaser, value);
        }

        private Brush _selectColor = Brushes.Black;
        public Brush selectColor
        {
            get => _selectColor;
            set => SetProperty(ref _selectColor, value);
        }

        private Brush _background = Brushes.Transparent;
        public Brush Background
        {
            get => _background;
            set => SetProperty(ref _background, value);
        }

        public bool IsSelected { get; private set; }

        public int positionX { get; }
        public int positionY { get; }

        public SquareViewModel(int positionX, int positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;
        }

        public Direction FireLaser(Direction firingDirection)
        {
            var inDirection = GetInDirection(firingDirection);
            activeLaser = new LaserBeamViewModel(inDirection, activePiece, activeLaser);

            if (activePiece != null)
            {
                var outDirection = activePiece.ResolveLaserDirection(inDirection);

                if (outDirection == Direction.Kill)
                {
                    activePiece = null;
                }

                return outDirection;
            }

            return firingDirection;
        }

        public void Select(bool selected)
        {
            IsSelected = selected;
            selectColor = selected ? Brushes.LawnGreen : Brushes.Black;
        }

        public void MovePiece(SquareViewModel nextSquare)
        {
            activePiece?.MovePiece(this, nextSquare);
        }

        private Direction GetInDirection(Direction firingDirection)
        {
            return firingDirection switch
            {
                Direction.Down => Direction.Up,
                Direction.Up => Direction.Down,
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                _ => firingDirection // Consider throwing an exception for invalid direction
            };
        }

        public void ClearLaser() => activeLaser = null;

        public void ClearPiece() => activePiece = null;

        public void SetSquareColor(int player)
        {
            Background = player switch
            {
                1 => Brushes.LightGray,
                2 => Brushes.IndianRed,
                _ => Background // Keep the existing background if player is not 1 or 2
            };
        }
    }
}
