using Khet2._0.CustomTypes;
using Khet2._0.Events;
using Khet2._0.MVVM.Models;
using Stylet;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Khet2._0.MVVM.ViewModel
{
    public class BoardViewModel : Screen
    {
        private MoveModel _moveModel;
        private LaserModel _laserModel;

        private MyGrid _grid;
        public MyGrid grid { get => _grid; set => SetAndNotify(ref _grid, value); }

        //private Index _selectedSquareIndex;

        public BoardViewModel(BoardModel boardModel, MoveModel moveModel, LaserModel laserModel, EventAggregator eventAggregator)
        {
            _moveModel = moveModel;
            _laserModel = laserModel;


            grid = boardModel.CreateGrid();
            boardModel.ClassicSetUp(grid);

            laserModel.SetGrid(grid);

        }
    }
}
