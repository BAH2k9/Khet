using Khet.Stylet.MVVM.Models;
using Stylet;

namespace Khet.Stylet.MVVM.ViewModels
{
    public class BoardViewModel : Screen
    {
        private MoveModel _moveModel;
        private BoardConfigurationModel _boardConfigurationModel;

        private GridModel _grid;
        public GridModel grid { get => _grid; set => SetAndNotify(ref _grid, value); }

        public BoardViewModel(MoveModel moveModel, BoardConfigurationModel boardConfigurationModel)
        {
            _moveModel = moveModel;
            _boardConfigurationModel = boardConfigurationModel;

            grid = _boardConfigurationModel.CreateGrid();
        }

        public void ClickSquare()
        {
            var a = 0;
        }

        //piece movement
        //configuration
        //player information
    }
}
