using Khet.Wpf.AbstractClasses;
using Khet.Wpf.Enums;
using Khet.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Wpf.Models
{
    public class BoardConfiguration
    {
        public static GridModel Classic(GridModel squareViewModels)
        {

            // Standard Configuration
            squareViewModels[3][0].activePiece = new PyramidViewModel(Pyramid.bl, 1);
            squareViewModels[4][0].activePiece = new PyramidViewModel(Pyramid.tl, 1);

            squareViewModels[1][2].activePiece = new PyramidViewModel(Pyramid.tr, 1);
            squareViewModels[3][2].activePiece = new PyramidViewModel(Pyramid.tr, 2);
            squareViewModels[4][2].activePiece = new PyramidViewModel(Pyramid.br, 2);
            squareViewModels[7][2].activePiece = new PyramidViewModel(Pyramid.br, 2);

            squareViewModels[2][3].activePiece = new PyramidViewModel(Pyramid.br, 2);
            squareViewModels[7][3].activePiece = new ObeliskViewModel(2);

            squareViewModels[0][4].activePiece = new ObeliskViewModel(1);
            squareViewModels[3][4].activePiece = new DjedViewModel(Djed.dl, 1);
            squareViewModels[4][4].activePiece = new DjedViewModel(Djed.dr, 2);
            squareViewModels[7][4].activePiece = new PharaohViewModel(2);

            squareViewModels[0][5].activePiece = new PharaohViewModel(1);
            squareViewModels[3][5].activePiece = new DjedViewModel(Djed.dr, 1);
            squareViewModels[4][5].activePiece = new DjedViewModel(Djed.dl, 2);
            squareViewModels[7][5].activePiece = new ObeliskViewModel(2);

            squareViewModels[0][6].activePiece = new ObeliskViewModel(1);
            squareViewModels[5][6].activePiece = new PyramidViewModel(Pyramid.tl, 1);

            squareViewModels[0][7].activePiece = new PyramidViewModel(Pyramid.tl, 1);
            squareViewModels[3][7].activePiece = new PyramidViewModel(Pyramid.tl, 1);
            squareViewModels[4][7].activePiece = new PyramidViewModel(Pyramid.bl, 1);
            squareViewModels[6][7].activePiece = new PyramidViewModel(Pyramid.bl, 2);

            squareViewModels[3][9].activePiece = new PyramidViewModel(Pyramid.br, 2);
            squareViewModels[4][9].activePiece = new PyramidViewModel(Pyramid.tr, 2);

            return squareViewModels;
        }

        public static GridModel Dynasty(GridModel squareViewModels)
        {
            // Standard Configuration
            squareViewModels[2][0].activePiece = new PyramidViewModel(Pyramid.bl, 1);
            squareViewModels[3][0].activePiece = new PyramidViewModel(Pyramid.tl, 1);

            squareViewModels[3][2].activePiece = new DjedViewModel(Djed.dl, 1);

            squareViewModels[4][3].activePiece = new PyramidViewModel(Pyramid.br, 1);
            squareViewModels[5][3].activePiece = new DjedViewModel(Djed.dr, 2);
            squareViewModels[7][3].activePiece = new PyramidViewModel(Pyramid.br, 2);


            squareViewModels[0][4].activePiece = new PyramidViewModel(Pyramid.tr, 1);
            squareViewModels[2][4].activePiece = new PyramidViewModel(Pyramid.tr, 1);
            squareViewModels[3][4].activePiece = new PyramidViewModel(Pyramid.br, 2);
            squareViewModels[5][4].activePiece = new ObeliskViewModel(2);
            squareViewModels[6][4].activePiece = new PharaohViewModel(2);
            squareViewModels[7][4].activePiece = new ObeliskViewModel(2);

            squareViewModels[0][5].activePiece = new ObeliskViewModel(1);
            squareViewModels[1][5].activePiece = new PharaohViewModel(1);
            squareViewModels[2][5].activePiece = new ObeliskViewModel(1);
            squareViewModels[4][5].activePiece = new PyramidViewModel(Pyramid.tl, 1);
            squareViewModels[5][5].activePiece = new PyramidViewModel(Pyramid.bl, 2);
            squareViewModels[7][5].activePiece = new PyramidViewModel(Pyramid.bl, 2);

            squareViewModels[0][6].activePiece = new PyramidViewModel(Pyramid.tl, 1);
            squareViewModels[0][6].activePiece = new DjedViewModel(Djed.dr, 1);
            squareViewModels[0][6].activePiece = new PyramidViewModel(Pyramid.tl, 2);

            squareViewModels[4][7].activePiece = new DjedViewModel(Djed.dl, 2);

            squareViewModels[4][9].activePiece = new PyramidViewModel(Pyramid.br, 2);
            squareViewModels[5][9].activePiece = new PyramidViewModel(Pyramid.tr, 2);

            return squareViewModels;
        }

        public static void SetSquareColor(GridModel squareViewModels)
        {

            foreach (var row in squareViewModels)
            {
                row[0].SetSquareColor(1);
                row[9].SetSquareColor(2);
            }
            squareViewModels[0][1].SetSquareColor(2);
            squareViewModels[7][1].SetSquareColor(2);
            squareViewModels[0][8].SetSquareColor(1);
            squareViewModels[7][8].SetSquareColor(1);
        }
    }
}
