using Khet.Wpf.Enums;
using Khet.Wpf.ViewModels;
using System.Collections.ObjectModel;

namespace Khet.Wpf.Models
{
    public class GridModel : ObservableCollection<ObservableCollection<SquareViewModel>>
    {
        public static readonly int rows = 8;
        public static readonly int cols = 10;
        public static GridModel Create()
        {
            var squareViewModels = new GridModel();

            for (int i = 0; i < rows; i++)
            {
                squareViewModels.Add(new ObservableCollection<SquareViewModel>());

                for (int j = 0; j < cols; j++)
                {
                    squareViewModels[i].Add(new SquareViewModel());
                }
            }

            return SetBoardConfiguration(squareViewModels);
        }

        public static GridModel SetBoardConfiguration(GridModel squareViewModels)
        {

            squareViewModels[3][0].activePiece = new DjedViewModel(Djed.dl);
            squareViewModels[3][7].activePiece = new PyramidViewModel(Pyramid.tl);
            squareViewModels[3][9].activePiece = new PyramidViewModel(Pyramid.br);
            

            return squareViewModels;
        }

        public static bool InBounds(int i, int j)
        {
            if(i >= 0 && j >= 0 && i< rows && j < cols )
            {
                return true;
            }

            return false;
        }

        public static void ClearLaser(GridModel squareViewModels)
        {
            foreach (var row in squareViewModels)
            {
                foreach (var square in row)
                {
                    square.Clear();
                }
            }
        }
    }
}
