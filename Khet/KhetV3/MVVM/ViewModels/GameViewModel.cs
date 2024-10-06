using Khet3.Enums;
using KhetV3.Services;
using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.MVVM.ViewModels
{
    public class GameViewModel : Screen
    {
        public BoardViewModel BoardViewModel { get; set; }
        private FireLaserService _fireLaserService { get; set; }

        private readonly int rows = 8;
        private readonly int cols = 10;
        public GameViewModel(BoardViewModel boardViewModel, FireLaserService fireLaserService)
        {
            this.BoardViewModel = boardViewModel;
            this.BoardViewModel.SetDimensions(rows, cols);
            this.BoardViewModel.Initialise();

            _fireLaserService = fireLaserService;
            _fireLaserService.SetBoardDimensions(rows, cols);

        }

        public void ExecuteFireLaserP1()
        {
            Trace.WriteLine("Player 1 fire laser clicked!");
            _fireLaserService.CalculateLaserPath((7, 9), Direction.Up);
        }

        public void ExecuteFireLaserP2()
        {
            Trace.WriteLine("Player 2 fire laser clicked!");
            _fireLaserService.CalculateLaserPath((0, 0), Direction.Down);
        }



    }
}
