using Khet.Wpf.AbstractClasses;
using Khet.Wpf.Enums;
using Khet.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Wpf.Models
{
    public class BoardConfiguration
    {
        private GridModel _squareViewModels;
        public BoardConfiguration(GridModel squareViewModels)
        {
            _squareViewModels = squareViewModels;
            
        }
        public GridModel SetClassic()
        {
            GridModel.ClearGrid(_squareViewModels);

            // Standard Configuration
            _squareViewModels[3][0].activePiece = new PyramidViewModel(Pyramid.BL, 1);
            _squareViewModels[4][0].activePiece = new PyramidViewModel(Pyramid.TL, 1);
            
            _squareViewModels[1][2].activePiece = new PyramidViewModel(Pyramid.TR, 1);
            _squareViewModels[3][2].activePiece = new PyramidViewModel(Pyramid.TR, 2);
            _squareViewModels[4][2].activePiece = new PyramidViewModel(Pyramid.BR, 2);
            _squareViewModels[7][2].activePiece = new PyramidViewModel(Pyramid.BR, 2);
            
            _squareViewModels[2][3].activePiece = new PyramidViewModel(Pyramid.BR, 2);
            _squareViewModels[7][3].activePiece = new ObeliskViewModel(2);
            
            _squareViewModels[0][4].activePiece = new ObeliskViewModel(1);
            _squareViewModels[3][4].activePiece = new DjedViewModel(Djed.DL, 1);
            _squareViewModels[4][4].activePiece = new DjedViewModel(Djed.DR, 2);
            _squareViewModels[7][4].activePiece = new PharaohViewModel(2);
            
            _squareViewModels[0][5].activePiece = new PharaohViewModel(1);
            _squareViewModels[3][5].activePiece = new DjedViewModel(Djed.DR, 1);
            _squareViewModels[4][5].activePiece = new DjedViewModel(Djed.DL, 2);
            _squareViewModels[7][5].activePiece = new ObeliskViewModel(2);
            
            _squareViewModels[0][6].activePiece = new ObeliskViewModel(1);
            _squareViewModels[5][6].activePiece = new PyramidViewModel(Pyramid.TL, 1);
            
            _squareViewModels[0][7].activePiece = new PyramidViewModel(Pyramid.TL, 1);
            _squareViewModels[3][7].activePiece = new PyramidViewModel(Pyramid.TL, 1);
            _squareViewModels[4][7].activePiece = new PyramidViewModel(Pyramid.BL, 1);
            _squareViewModels[6][7].activePiece = new PyramidViewModel(Pyramid.BL, 2);
            
            _squareViewModels[3][9].activePiece = new PyramidViewModel(Pyramid.BR, 2);
            _squareViewModels[4][9].activePiece = new PyramidViewModel(Pyramid.TR, 2);

            return _squareViewModels;
        }

        public void SetDynasty()
        {
            GridModel.ClearGrid(_squareViewModels);

            // Standard Configuration
            _squareViewModels[2][0].activePiece = new PyramidViewModel(Pyramid.BL, 1);
            _squareViewModels[3][0].activePiece = new PyramidViewModel(Pyramid.TL, 1);
            
            _squareViewModels[3][2].activePiece = new DjedViewModel(Djed.DL, 1);
            
            _squareViewModels[4][3].activePiece = new PyramidViewModel(Pyramid.BR, 1);
            _squareViewModels[5][3].activePiece = new DjedViewModel(Djed.DR, 2);
            _squareViewModels[7][3].activePiece = new PyramidViewModel(Pyramid.BR, 2);
                        
            _squareViewModels[0][4].activePiece = new PyramidViewModel(Pyramid.TR, 1);
            _squareViewModels[2][4].activePiece = new PyramidViewModel(Pyramid.TR, 1);
            _squareViewModels[3][4].activePiece = new PyramidViewModel(Pyramid.BR, 2);
            _squareViewModels[5][4].activePiece = new ObeliskViewModel(2);
            _squareViewModels[6][4].activePiece = new PharaohViewModel(2);
            _squareViewModels[7][4].activePiece = new ObeliskViewModel(2);
            
            _squareViewModels[0][5].activePiece = new ObeliskViewModel(1);
            _squareViewModels[1][5].activePiece = new PharaohViewModel(1);
            _squareViewModels[2][5].activePiece = new ObeliskViewModel(1);
            _squareViewModels[4][5].activePiece = new PyramidViewModel(Pyramid.TL, 1);
            _squareViewModels[5][5].activePiece = new PyramidViewModel(Pyramid.BL, 2);
            _squareViewModels[7][5].activePiece = new PyramidViewModel(Pyramid.BL, 2);
            
            _squareViewModels[0][6].activePiece = new PyramidViewModel(Pyramid.TL, 1);
            _squareViewModels[0][6].activePiece = new DjedViewModel(Djed.DR, 1);
            _squareViewModels[0][6].activePiece = new PyramidViewModel(Pyramid.TL, 2);
            
            _squareViewModels[4][7].activePiece = new DjedViewModel(Djed.DL, 2);
            
            _squareViewModels[4][9].activePiece = new PyramidViewModel(Pyramid.BR, 2);
            _squareViewModels[5][9].activePiece = new PyramidViewModel(Pyramid.TR, 2);
        }

        public void SetSquareColor()
        {
            foreach (var row in _squareViewModels)
            {
                row[0].SetSquareColor(1);
                row[9].SetSquareColor(2);
            }
            _squareViewModels[0][1].SetSquareColor(2);
            _squareViewModels[7][1].SetSquareColor(2);
            _squareViewModels[0][8].SetSquareColor(1);
            _squareViewModels[7][8].SetSquareColor(1);
        }

        public void SetNames(ObservableCollection<BoardConfig> Names)
        {
            Names.Add(BoardConfig.Classic);
            Names.Add(BoardConfig.Dynasty);

        }

        public GridModel GetGridModel()
        {
            return _squareViewModels;
        }
    }
}
