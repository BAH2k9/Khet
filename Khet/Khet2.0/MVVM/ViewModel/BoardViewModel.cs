using Khet2._0.CustomTypes;
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

        public BoardViewModel()
        {
            CreateGrid();
        }

        public void CreateGrid()
        {
            var squareViewModels = new MyGrid();

            for (int i = 0; i < 8; i++)
            {
                squareViewModels.Add(new BindableCollection<SquareViewModel>());

                for (int j = 0; j < 10; j++)
                {
                    squareViewModels[i].Add(new SquareViewModel());
                }
            }

            grid = squareViewModels;
        }
    }
}
