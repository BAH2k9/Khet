using Khet2._0.CustomTypes;
using Khet2._0.Events;
using Khet2._0.MVVM.ViewModel;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet2._0.MVVM.Models
{
    public class GameModel : IHandle<GameBeginEvent>, IHandle<LaserFireEvent>
    {
        private MyGrid _grid;
        private GameViewModel _gameViewModel;
        public GameModel(GameViewModel gameViewModel)
        {
            _grid = gameViewModel.boardViewModel.grid;
            _gameViewModel = gameViewModel;

            Player1Turn();
        }

        private void Player1Turn()
        {
            _gameViewModel.canPlayer1Fire = true;
        }

        private void Player2Turn()
        {
            _gameViewModel.canPlayer2Fire = true;
        }

        public void Handle(LaserFireEvent message)
        {
            throw new NotImplementedException();
        }

        public void Handle(GameBeginEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
