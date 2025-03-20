using KhetV4.Core.Factory;
using KhetV4.Core.Handlers;
using KhetV4.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV4.MVVM.ViewModels
{
    public class BoardViewModel
    {
        public Dictionary<(int, int), SquareViewModel> _squareViewModels; // Bindable to grid

        readonly LaserService _laserService; // Calculate Laser path and animate it

        readonly LeftClickHandler _leftClickHandler; // Converts user input to game logic

        public BoardViewModel(LaserService laserService, LeftClickHandler leftClickHandler)
        {
            _squareViewModels = BoardConfiguration.CreateBoard(1);
            _laserService = laserService;
            _leftClickHandler = leftClickHandler;
        }

        public void HandleLeftClick()
        {


            var order = _leftClickHandler.Handle();

            if (order == 0)
            {
                return;
            }

            _laserService.Start(order, _squareViewModels);
        }
    }
}