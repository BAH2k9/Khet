using Khet.Wpf.Core;
using Khet.Wpf.Enums;
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
        private int _rows = 8;
        private int _cols = 10;

        public ICommand Player1FireCommand { get; }
        public ICommand Player2FireCommand { get; }

        public ObservableCollection<ObservableCollection<SquareViewModel>> squareViewModels { get; set; } = new ObservableCollection<ObservableCollection<SquareViewModel>>();

        public BoardViewModel()
        {

            Player1FireCommand = new RelayCommand(ExecuteLeftClick);
            Player2FireCommand = new RelayCommand(ExecuteRightClick);


            CreateSquares();

            SetBoardConfiguration();

           // squareViewModels[0][0].FireLaser(Direction.down);
        }

        private void SetBoardConfiguration()
        {

            squareViewModels[3][3].activePiece = new DjedViewModel(Djed.dl);
            squareViewModels[5][5].activePiece = new PyramidViewModel(Pyramid.tl);
        }

        private void CreateSquares()
        {
            for (int i = 0; i < _rows; i++)
            {
                squareViewModels.Add(new ObservableCollection<SquareViewModel>());

                for (int j = 0; j < _cols; j++)
                {
                    squareViewModels[i].Add(new SquareViewModel());

                }
            }
        }

        private void resolveLeftLaser(int x, int y)
        {
            //while fileLaser != kill


        }

        public void ExecuteLeftClick(object obj)
        {
            squareViewModels[0][0].FireLaser(Direction.down);
        }
        public void ExecuteRightClick(object obj)
        {
            squareViewModels[7][9].FireLaser(Direction.up);
        }



    }
}
