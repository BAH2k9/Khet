using Khet.Stylet.MVVM.Models.Pieces;
using Khet.Stylet.MVVM.Models;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Khet.Stylet.MVVM.Models.MyPieces;

namespace Khet.Stylet.MVVM.ViewModels
{
    public class SquareViewModel : Screen
    {
        public LaserBeamViewModel? activeLaser { get; set; } = null;

        public IPiece? activePiece { get; set; } = null;

        public SquareViewModel(Position position)
        {

        }

        private void UpdateLaser()
        {
            if (activePiece.IsKilled(inDirection))
            {

            }
            else
            {
                activeLaser = new LaserBeamViewModel(pieceOrientation);
            }



        }

        public void RotatePiece(RotateDirection direction)
        {
            activePiece.RotatePiece(direction);
        }

        //square properties 
        /*
         * square: piece + laser
         * piece: player + specific piece
         * laser: on/off, where on square
         */
    }
}
