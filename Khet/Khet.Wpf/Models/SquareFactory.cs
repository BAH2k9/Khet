using Khet.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Wpf.Models
{
    public class SquareFactory
    {
        private int _rows = 8;
        private int _cols = 10;

        public List<List<SquareViewModel>> myList { get; set; } = new List<List<SquareViewModel>>() ;


        private ObservableCollection<SquareViewModel> squareViewModels = new ObservableCollection<SquareViewModel>();
        public SquareFactory() 
        {
            CreateSquares();

            SetNeighbours();

            var a = 1;
        }


        private void CreateSquares()
        {
            for (int i = 0; i < _rows; i++)
            {
                myList.Add(new List<SquareViewModel>());

                for (int j = 0; j < _cols; j++)
                {
                    myList[i].Add(new SquareViewModel());
                }
            }
        }

        private void SetNeighbours()
        {
            for (int i = 0; i < _rows ; i++)
            {
                for (int j = 0; j < _cols ; j++)
                {

                    if(i ==0)
                    {
                        myList[i][j].upNeighbour=null;
                    }
                    else
                    {
                        myList[i][j].upNeighbour = myList[i-1][j];
                    }

                    if(i == _rows-1)
                    {
                        myList[i][j].downNeighbour=null;
                    }
                    else
                    {
                        myList[i][j].downNeighbour = myList[i+1][j];
                    }


                    if(j==0)
                    {
                        myList[i][j].leftNeighbour = null;
                    }
                    else
                    {
                        myList[i][j].leftNeighbour = myList[i][j-1];
                    }

                    if(j == _cols-1)
                    {
                        myList[i][j].rightNeighbour = null;
                    }
                    else
                    {
                        myList[i][j].rightNeighbour=myList[i][j+1];
                    }

                    myList[i][j].SetLaser();

                }
            }
        }
    }
}
