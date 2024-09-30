using Khet2._0.CustomTypes;
using Khet2._0.Events;
using Khet2._0.MVVM.Models;
using Stylet;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Khet2._0.MVVM.ViewModel
{
    public class BoardViewModel : Screen
    {
        private MoveModel _moveModel;
        private LaserModel _laserModel;
        private BoardModel _boardModel;

        private MyGrid _grid;
        public MyGrid grid { get => _grid; set => SetAndNotify(ref _grid, value); }

        //private Index _selectedSquareIndex;

        public BoardViewModel(BoardModel boardModel,
                                MoveModel moveModel,
                                LaserModel laserModel,
                                EventAggregator eventAggregator)
        {
            _boardModel = boardModel;
            _moveModel = moveModel;
            _laserModel = laserModel;


            grid = boardModel.CreateGrid();
            boardModel.ClassicSetUp(grid);

            laserModel.SetGrid(grid);

        }

    }
}
