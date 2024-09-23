using Khet.Stylet.MVVM.Models.MyPieces;
using Khet.Stylet.MVVM.ViewModels;
using Khet.Stylet.MVVM.Models.D;
using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Khet.Stylet.MVVM.Models
{
    public class BoardConfigurationModel
    {
        public static readonly int rows = 8;
        public static readonly int cols = 10;



        public BoardConfigurationModel()
        {

        }

        public GridModel CreateGrid()
        {
            var squareViewModels = new GridModel();

            for (int i = 0; i < rows; i++)
            {
                squareViewModels.Add(new BindableCollection<SquareViewModel>());

                for (int j = 0; j < cols; j++)
                {
                    var position = new Position { i = i, j = j };
                    squareViewModels[i].Add(new SquareViewModel(position, ));
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


