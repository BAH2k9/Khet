using Khet.Stylet.MVVM.ViewModels;
using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Stylet.MVVM.Models
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
                    squareViewModels[i].Add(new SquareViewModel(i, j));
                }
            }

            return squareViewModels;
        }

        public static bool InBounds(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < rows && j < cols)
            {
                return true;
            }

            return false;
        }
    }
}
