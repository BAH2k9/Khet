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

namespace Khet.Wpf.ViewModels
{
    public class SquareViewModel : ViewModelBase
    {

        private IPiece? _activePiece;
        public IPiece? activePiece { get => _activePiece; set => SetProperty(ref _activePiece, value); }

        private ViewModelBase _activeLaser;
        public ViewModelBase activeLaser { get => _activeLaser; set => SetProperty(ref _activeLaser, value); }

        public SquareViewModel()
        {

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

        public void DisplayLaser()
        {

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
