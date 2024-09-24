using Stylet;
using System;

namespace Khet2._0.MVVM.ViewModel
{
    public class GameViewModel : Screen
    {
        private BoardViewModel _boardViewModel;
        public BoardViewModel boardViewModel { get => _boardViewModel; set => SetAndNotify(ref _boardViewModel, value); }

        public GameViewModel(BoardViewModel boardViewModel)
        {
            this.boardViewModel = boardViewModel;
        }

    }
}