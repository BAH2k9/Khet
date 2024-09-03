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
        public SquareViewModel? upNeighbour {  get; set; }
        public SquareViewModel? downNeighbour {  get; set; }
        public SquareViewModel? leftNeighbour {  get; set; }
        public SquareViewModel? rightNeighbour {  get; set; }

        private IPiece _activePiece;
        public IPiece activePiece { get => _activePiece; set => SetProperty(ref _activePiece, value); }

        private ViewModelBase _activeLaser;
        public ViewModelBase activeLaser { get => _activeLaser; set => SetProperty(ref _activeLaser, value); }

        public SquareViewModel()
        {

        }


        public void FireLaser(Direction firingDirection)
        {

            var inDirection = getInDirection(firingDirection);
            Direction? outDirection = firingDirection;

            // Display this sqaures laser
            activeLaser = new LaserBeamViewModel(inDirection, activePiece);

            

            if (activePiece != null)
            {
               outDirection = activePiece?.ResolveLaserDirection(inDirection);
                
            }



            switch (outDirection)
            {
                case Direction.down:
                    downNeighbour?.FireLaser(Direction.down);
                    break;

                case Direction.up:
                    upNeighbour?.FireLaser(Direction.up);
                    break;

                case Direction.left:
                    leftNeighbour?.FireLaser(Direction.left);
                    break;

                case Direction.right:
                    rightNeighbour?.FireLaser(Direction.right);
                    break;
                case Direction.kill:
                    activePiece?.ClearDisplay();
                    activePiece = null;
                    break;
            }
        }

        private Direction getInDirection(Direction firingDirection)
        {
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

        public void Clear()
        {
            activeLaser = null;
            //activePiece = null;
        }
    }
}
