using Khet2._0.CustomTypes;
using Khet2._0.Enums;
using Khet2._0.MVVM.ViewModel;
using Stylet;
//using System.Windows.Controls;

namespace Khet2._0.MVVM.Models
{
    public class BoardModel
    {
        private readonly int _rows = 8;
        private readonly int _columns = 10;

        private EventAggregator _eventAggregator;
        public BoardModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public MyGrid CreateGrid()
        {
            var squareViewModels = new MyGrid();

            for (int i = 0; i < _rows; i++)
            {
                squareViewModels.Add(new BindableCollection<SquareViewModel>());

                for (int j = 0; j < _columns; j++)
                {
                    var index = new Idx { row = i, column = j };
                    squareViewModels[i].Add(new SquareViewModel(_eventAggregator, index));
                }
            }

            return squareViewModels;
        }

        public void ClassicSetUp(MyGrid grid)
        {
            // Standard Configuration
            grid[3][0].ActivePiece = new PyramidViewModel(Orientations.NE, 1);
            grid[4][0].ActivePiece = new PyramidViewModel(Orientations.SE, 1);

            grid[1][2].ActivePiece = new PyramidViewModel(Orientations.SW, 1);
            grid[3][2].ActivePiece = new PyramidViewModel(Orientations.SW, 2);
            grid[4][2].ActivePiece = new PyramidViewModel(Orientations.NW, 2);
            grid[7][2].ActivePiece = new PyramidViewModel(Orientations.NW, 2);

            grid[2][3].ActivePiece = new PyramidViewModel(Orientations.NW, 2);
            grid[7][3].ActivePiece = new ObeliskViewModel(2);

            grid[0][4].ActivePiece = new ObeliskViewModel(1);
            grid[3][4].ActivePiece = new DjedViewModel(Orientations.NE, 1);
            grid[4][4].ActivePiece = new DjedViewModel(Orientations.NW, 2);
            grid[7][4].ActivePiece = new PharaohViewModel(2);

            grid[0][5].ActivePiece = new PharaohViewModel(1);
            grid[3][5].ActivePiece = new DjedViewModel(Orientations.NW, 1);
            grid[4][5].ActivePiece = new DjedViewModel(Orientations.NE, 2);
            grid[7][5].ActivePiece = new ObeliskViewModel(2);

            grid[0][6].ActivePiece = new ObeliskViewModel(1);
            grid[5][6].ActivePiece = new PyramidViewModel(Orientations.SE, 1);

            grid[0][7].ActivePiece = new PyramidViewModel(Orientations.SE, 1);
            grid[3][7].ActivePiece = new PyramidViewModel(Orientations.SE, 1);
            grid[4][7].ActivePiece = new PyramidViewModel(Orientations.NE, 1);
            grid[6][7].ActivePiece = new PyramidViewModel(Orientations.NE, 2);

            grid[3][9].ActivePiece = new PyramidViewModel(Orientations.NW, 2);
            grid[4][9].ActivePiece = new PyramidViewModel(Orientations.SW, 2);
        }
    }
}
