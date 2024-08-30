using Khet.Wpf.Core;
using Khet.Wpf.Enums;
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

        private PieceViewModel _activePiece;
        public PieceViewModel activePiece { get => _activePiece; set => SetProperty(ref _activePiece, value); }

        private ViewModelBase _activeLaser;
        public ViewModelBase activeLaser { get => _activeLaser; set => SetProperty(ref _activeLaser, value); }

        public SquareViewModel()
        {

        }

        private void DisplayMyLaser(Direction inDirection)
        {
           if(inDirection == Direction.down || inDirection == Direction.up)
            {
                activeLaser = new VerticalBeamViewModel();
            }

            if (inDirection == Direction.left || inDirection == Direction.right)
            {
                activeLaser = new HorizontalBeamViewModel();
            }

        }

        public void FireLaser(Direction inDirection)
        {
            DisplayMyLaser(inDirection);

           var outDirection = OutLaserDirection(inDirection);

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
            }
        }

        private Direction OutLaserDirection(Direction inDirection)
        {
            // logic needs to go here to determine the laser direction based on the piece and its orientation
            Direction outDirection = inDirection;

            if (activePiece == null)
            {
                return outDirection;
            }
            

            switch(activePiece?.state)
            {
                case State.dl:
                    if(inDirection == Direction.down)
                    {
                        outDirection = Direction.right;
                        break;
                    }

                    if (inDirection == Direction.right)
                    {
                        outDirection = Direction.down;
                        break;
                    }

                    if (inDirection == Direction.left)
                    {
                        outDirection = Direction.up;
                        break;
                    }

                    if (inDirection == Direction.up)
                    {
                        outDirection = Direction.left;
                        break;
                    }

                    break;
            }

            return outDirection;
        }
    }
}
