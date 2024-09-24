using Khet2._0.CustomTypes;
using Khet2._0.MVVM.Models;
using Stylet;
using System;
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
        private MyGrid _grid;
        public MyGrid grid { get => _grid; set => SetAndNotify(ref _grid, value); }

        public BoardViewModel(BoardModel boardModel)
        {
            grid = boardModel.CreateGrid();

            boardModel.ClassicSetUp(grid);

        }

    }
}
