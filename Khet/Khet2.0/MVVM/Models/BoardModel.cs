using Khet2._0.CustomTypes;
using Khet2._0.Enums;
using Khet2._0.Events;
using Khet2._0.Interfaces;
using Khet2._0.MVVM.ViewModel;
using Stylet;
using System.Collections.Generic;
//using System.Windows.Controls;

namespace Khet2._0.MVVM.Models
{
    public class BoardModel : IHandle<PieceMovedEvent>, IHandle<BackButtonClickEvent>
    {
        private readonly int _rows = 8;
        private readonly int _columns = 10;

        private EventAggregator _eventAggregator;

        private MyGrid _grid = new MyGrid();

        private SquareViewModel _square1;
        private SquareViewModel _square2;
        private int _playerTurn;

        public BoardModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public MyGrid CreateGrid()
        {

            for (int i = 0; i < _rows; i++)
            {
                _grid.Add(new BindableCollection<SquareViewModel>());

                for (int j = 0; j < _columns; j++)
                {
                    _grid[i].Add(new SquareViewModel(_eventAggregator, new Idx(i, j)));
                }
            }

            return _grid;
        }

        public void ClassicSetUp(MyGrid grid)
        {
            // Standard Configuration
            grid[3][0].ActivePiece = new PyramidViewModel(Orientations.NE, 2);
            grid[4][0].ActivePiece = new PyramidViewModel(Orientations.SE, 2);

            grid[1][2].ActivePiece = new PyramidViewModel(Orientations.SW, 2);
            grid[3][2].ActivePiece = new PyramidViewModel(Orientations.SW, 1);
            grid[4][2].ActivePiece = new PyramidViewModel(Orientations.NW, 1);
            grid[7][2].ActivePiece = new PyramidViewModel(Orientations.NW, 1);

            grid[2][3].ActivePiece = new PyramidViewModel(Orientations.NW, 1);
            grid[7][3].ActivePiece = new ObeliskViewModel(1);

            grid[0][4].ActivePiece = new ObeliskViewModel(2);
            grid[3][4].ActivePiece = new DjedViewModel(Orientations.NE, 2);
            grid[4][4].ActivePiece = new DjedViewModel(Orientations.NW, 1);
            grid[7][4].ActivePiece = new PharaohViewModel(1);

            grid[0][5].ActivePiece = new PharaohViewModel(2);
            grid[3][5].ActivePiece = new DjedViewModel(Orientations.NW, 2);
            grid[4][5].ActivePiece = new DjedViewModel(Orientations.NE, 1);
            grid[7][5].ActivePiece = new ObeliskViewModel(1);

            grid[0][6].ActivePiece = new ObeliskViewModel(2);
            grid[5][6].ActivePiece = new PyramidViewModel(Orientations.SE, 2);

            grid[0][7].ActivePiece = new PyramidViewModel(Orientations.SE, 2);
            grid[3][7].ActivePiece = new PyramidViewModel(Orientations.SE, 2);
            grid[4][7].ActivePiece = new PyramidViewModel(Orientations.NE, 2);
            grid[6][7].ActivePiece = new PyramidViewModel(Orientations.NE, 1);

            grid[3][9].ActivePiece = new PyramidViewModel(Orientations.NW, 1);
            grid[4][9].ActivePiece = new PyramidViewModel(Orientations.SW, 1);

        }


        public void Handle(PieceMovedEvent e)
        {
            _square1 = e.oldSquare;
            _square2 = e.newSquare;
            _playerTurn = e.player;
        }

        public void Handle(BackButtonClickEvent e)
        {
            var temp = _square1.ActivePiece;
            _square1.ActivePiece = _square2.ActivePiece;
            _square2.ActivePiece = temp;
            _square1.UnselectSquare();
            _square2.UnselectSquare();
            _eventAggregator.Publish(new PlayerChangeEvent(_playerTurn));
        }
    }
}
