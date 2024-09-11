using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Models;
using Khet.Wpf.Tests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Khet.Wpf.ViewModels
{
    public class BoardViewModel
    {
        public ICommand Player1FireCommand { get; }
        public ICommand Player2FireCommand { get; }

        //public ICommand StartDragCommand { get; }
        //public ICommand DropCommand { get; }

        public ICommand SelectClick { get; }
        public ICommand HoverCommand { get; }

        public SquareViewModel SelectedSquare { get; set; }
        public SquareViewModel HoverSquare { get; set; }
        public ICommand DropCommand { get; }


        public ICommand PyramidTestCommand { get; }
        public ICommand DjedTestCommand { get; }
        public ICommand ClearGridCommand { get; }
        public ICommand SetGridCommand { get; }

        public GridModel squareViewModels { get; set; } 

        public BoardViewModel()
        {

            squareViewModels = GridModel.Create();
            //GridModel.SetBoardConfiguration(squareViewModels);

            // Player1FireCommand = new RelayCommand(FireLaserPlayer1);
            // Player2FireCommand = new RelayCommand(FireLaserPlayer2);
            //StartDragCommand = new RelayCommand<SquareViewModel>(StartDrag);
            //DropCommand = new RelayCommand<SquareViewModel>(Drop);

            SelectClick = new RelayCommand<SquareViewModel>(ExecuteSelectClick);
            HoverCommand = new RelayCommand<SquareViewModel>(Hover);

            PyramidTestCommand = new RelayCommandAsync(param => PyramidTest.AllOrientations(squareViewModels));
            DjedTestCommand = new RelayCommandAsync(param => DjedTest.AllOrientations(squareViewModels));
            ClearGridCommand = new RelayCommand<object>(param => GridModel.ClearGrid(squareViewModels));
            SetGridCommand = new RelayCommand<object>(param => GridModel.SetBoardConfiguration(squareViewModels));


        }

        private void Hover(SquareViewModel squareViewModel)
        {
           
            this.HoverSquare = squareViewModel;
        }

        private void ExecuteSelectClick(SquareViewModel squareViewModel)
        {
            if (squareViewModel.activePiece != null)
            {
                this.SelectedSquare = squareViewModel;
                squareViewModel.Select(true);
            }

            if(this.SelectedSquare != squareViewModel)
            {
                this.HoverSquare.activePiece = this.SelectedSquare.activePiece;
                this.SelectedSquare.activePiece = null;
                this.SelectedSquare.Select(false);
            }

            

        }

        //private void StartDrag(SquareViewModel e)
        //{
        //    DragDrop.DoDragDrop(Application.Current.MainWindow, this, DragDropEffects.Move);
        //}

        //private void Drop(SquareViewModel e)
        //{
        //    if (e != null)
        //    {
        //        //if (e.Data.GetDataPresent(typeof(SquareViewModel)))
        //        //{
        //        //    var draggedSquare = e.Data.GetData(typeof(SquareViewModel)) as SquareViewModel;

        //        //    //if (draggedSquare != null)
        //        //    //{
        //        //    //    this.Piece = draggedSquare.Piece?.Clone(); // Clone the piece
        //        //    //    draggedSquare.Piece = null; // Clear the original piece
        //        //    //}
        //        //}
        //    }
            
        //}

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
