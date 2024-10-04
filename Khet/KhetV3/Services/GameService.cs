using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.Services
{
    class GameService
    {
        public GameService(FireLaserService fireLaserService)
        {

            //player
            //laserFiringService => outcome 
            //gameState (kill pharaoh => end game) 
            //          (waitingForPlayerClick)
            //          (playerFired)
            //          (pieceSelected)
            //previousState?
            //playerChange
            //game flow rules here


        }

        public void FireLaser(int player)
        {
            //start pos br for p1 or tl for p2
            //fireLaserService.CalculateLaserPath(startPos)
            Trace.WriteLine($"GameService: FireLaser ${player}");
        }





    }
}
