using KhetV4.MVVM.ViewModels;
using System;
using System.Collections.Generic;

namespace KhetV4.Core.Services
{
    public class LaserService
    {
        readonly AnimationService _animationService;

        readonly (int P1, int P2) LaserPosition;
        public LaserService(AnimationService animationService)
        {
            _animationService = animationService;
        }

        public void Start(int order, Dictionary<(int, int), SquareViewModel> board)
        {
            // This function can be run on a separate thread

            // Get Piece State from board
            // Calculate Laser path
            // Animate Laser path (Dispatch to UI thread)
        }
    }
}