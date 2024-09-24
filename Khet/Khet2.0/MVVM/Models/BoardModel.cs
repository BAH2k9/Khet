using Khet2._0.CustomTypes;
using Khet2._0.Enums;
using Khet2._0.MVVM.ViewModel;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Khet2._0.MVVM.Models
{
    public class BoardModel
    {
        private readonly int _rows = 8;
        private readonly int _columns = 10;
        public BoardModel()
        {

        }

        public MyGrid CreateGrid()
        {
            var squareViewModels = new MyGrid();

            for (int i = 0; i < _rows; i++)
            {
                squareViewModels.Add(new BindableCollection<SquareViewModel>());

                for (int j = 0; j < _columns; j++)
                {
                    squareViewModels[i].Add(new SquareViewModel());
                }
            }

            return squareViewModels;
        }

        public void ClassicSetUp(MyGrid grid)
        {
            grid[0][0].ActivePiece = new DjedViewModel(1) { orientation = Orientations.NW };
            grid[1][0].ActivePiece = new DjedViewModel(1) { orientation = Orientations.NE };
            grid[2][0].ActivePiece = new DjedViewModel(2) { orientation = Orientations.SE };
            grid[3][0].ActivePiece = new DjedViewModel(2) { orientation = Orientations.SW };

            grid[0][2].ActivePiece = new PyramidViewModel(1) { orientation = Orientations.NW };
            grid[1][2].ActivePiece = new PyramidViewModel(1) { orientation = Orientations.NE };
            grid[2][2].ActivePiece = new PyramidViewModel(2) { orientation = Orientations.SE };
            grid[3][2].ActivePiece = new PyramidViewModel(2) { orientation = Orientations.SW };

            grid[0][4].ActivePiece = new ObeliskViewModel(1);
            grid[1][4].ActivePiece = new ObeliskViewModel(1);
            grid[2][4].ActivePiece = new ObeliskViewModel(2);
            grid[3][4].ActivePiece = new ObeliskViewModel(2);

            grid[0][6].ActivePiece = new PharaohViewModel();
            grid[1][6].ActivePiece = new PharaohViewModel();
            grid[2][6].ActivePiece = new PharaohViewModel();
            grid[3][6].ActivePiece = new PharaohViewModel();
        }
    }
}
