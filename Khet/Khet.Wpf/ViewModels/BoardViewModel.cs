using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Exceptions;
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
    public class BoardViewModel : ViewModelBase
    {
        public ICommand SelectClick { get; }
        public ICommand PyramidTestCommand { get; }
        public ICommand DjedTestCommand { get; }
        public ICommand ClearGridCommand { get; }
        public ICommand SetGridCommand { get; }
        public ICommand LeftKeyCommand { get; }
        public ICommand RightKeyCommand { get; }
        public SquareViewModel SelectedSquare { get; set; } = new SquareViewModel(0,0) { IsSelected = false };

        private MoveModel _mover = new MoveModel();
        public GridModel squareViewModels { get; set; }

        private string _warningMessage;

        public string WarningMessage
        {
            get => _warningMessage;
            set
            {
                _warningMessage = value;
                OnPropertyChanged(nameof(WarningMessage));
            }
        }


        public BoardViewModel()
        {
            SelectClick = new RelayCommand<SquareViewModel>(ExecuteSelectClick);
            PyramidTestCommand = new RelayCommandAsync(param => PyramidTest.AllOrientations(squareViewModels));
            DjedTestCommand = new RelayCommandAsync(param => DjedTest.AllOrientations(squareViewModels));
            ClearGridCommand = new RelayCommand<object>(param => GridModel.ClearGrid(squareViewModels));
            SetGridCommand = new RelayCommand<object>(param => GridModel.SetBoardConfiguration(squareViewModels));
            RightKeyCommand = new RelayCommand<object>(param => RotatePiece(Rotate.Right));
            LeftKeyCommand = new RelayCommand<object>(param => RotatePiece(Rotate.Left));

            squareViewModels = GridModel.Create();

            GridModel.SetBoardConfiguration(squareViewModels);
            GridModel.SetSquareColor(squareViewModels);


        }

        private void ExecuteSelectClick(SquareViewModel squareViewModel)
        {
            try
            {
                WarningMessage = "";
                this.SelectedSquare = _mover.NewSquareClicked(squareViewModel);

            }
            catch(PieceMoveException ex)
            {
                WarningMessage = ex.Message;
            }
        }
        private void RotatePiece(Rotate rotation)
        {
            try
            {
                this.SelectedSquare.activePiece?.RotatePiece(rotation);
                WarningMessage = "";
            }
            catch(UserExceptions ex) 
            {
                WarningMessage = ex.Message;
            }
            
        }


    }
}
