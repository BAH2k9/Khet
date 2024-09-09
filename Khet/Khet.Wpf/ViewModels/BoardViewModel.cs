using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Models;
using Khet.Wpf.Tests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Khet.Wpf.ViewModels
{
    public class BoardViewModel
    {
        public ICommand Player1FireCommand { get; }
        public ICommand Player2FireCommand { get; }
        public ICommand PyramidTestCommand { get; }
        public ICommand DjedTestCommand { get; }
        public ICommand ClearGridCommand { get; }
        public ICommand SetGridCommand { get; }

        public GridModel squareViewModels { get; set; } 

        public BoardViewModel()
        {

            squareViewModels = GridModel.Create();
            //GridModel.SetBoardConfiguration(squareViewModels);

            Player1FireCommand = new RelayCommand(FireLaserPlayer1);
            Player2FireCommand = new RelayCommand(FireLaserPlayer2);
            PyramidTestCommand = new RelayCommandAsync(param => PyramidTest.AllOrientations(squareViewModels));
            DjedTestCommand = new RelayCommandAsync(param => DjedTest.AllOrientations(squareViewModels));
            ClearGridCommand = new RelayCommand(param => GridModel.ClearGrid(squareViewModels));
            SetGridCommand = new RelayCommand(param => GridModel.SetBoardConfiguration(squareViewModels));


            

            //_ = DjedTest.AllOrientations(squareViewModels);
            //_ = PyramidTest.AllOrientations(squareViewModels);


        }



        private void FireLaserPlayer1(object obj)
        {           
            FireLaser(squareViewModels, 0, 0, Direction.down);           
        }

        private void FireLaserPlayer2(object obj)
        {
            FireLaser(squareViewModels, 7, 9, Direction.up);
        }

        public static void FireLaser(GridModel squareViewModels, int i, int j, Direction direction)
        {
            GridModel.ClearLaser(squareViewModels);

            while (GridModel.InBounds(i, j) && direction != Direction.kill)
            {
                switch (direction = squareViewModels[i][j].FireLaser(direction))
                {
                    case Direction.up:
                        i--;
                        break;
                    case Direction.down:
                        i++;
                        break;
                    case Direction.left:
                        j--;
                        break;
                    case Direction.right:
                        j++;
                        break;

                    default: break;
                }
            }
        }

    }
}
