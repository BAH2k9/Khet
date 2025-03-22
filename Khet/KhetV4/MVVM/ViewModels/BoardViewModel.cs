using KhetV4.Core.ExtensionMethods;
using KhetV4.Core.Factory;
using KhetV4.Core.Handlers;
using KhetV4.Core.Services;
using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV4.MVVM.ViewModels
{
    public class BoardViewModel : Screen
    {

        BindableCollection<SquareViewModel> _displayBoard;
        public BindableCollection<SquareViewModel> DisplayBoard { get => _displayBoard; set => SetAndNotify(ref _displayBoard, value); } // Bindable to grid

        private Dictionary<(int, int), SquareViewModel> _boardDict;

        readonly LaserService _laserService; // Calculate Laser path and animate it

        readonly LeftClickHandler _leftClickHandler; // Converts user input to game logic

        public BoardViewModel(LaserService laserService, LeftClickHandler leftClickHandler)
        {
            _boardDict = BoardConfiguration.CreateBoard(1);
            DisplayBoard = _boardDict.Values.ToBindableCollection();
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

            _laserService.Start(order, _boardDict);
        }
    }
}