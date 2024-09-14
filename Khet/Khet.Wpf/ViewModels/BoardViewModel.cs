﻿using Khet.Wpf.Core;
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
        public ICommand SelectClick { get; }
        public ICommand PyramidTestCommand { get; }
        public ICommand DjedTestCommand { get; }
        public ICommand ClearGridCommand { get; }
        public ICommand SetGridCommand { get; }
        public ICommand LeftKeyCommand { get; }
        public ICommand RightKeyCommand { get; }
        public SquareViewModel SelectedSquare { get; set; } = new SquareViewModel() { Selected = false };
        public GridModel squareViewModels { get; set; } 


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
            // TODO: Logic needs to be sorted out here
            // Set the selected square on first pass
            if (this.SelectedSquare?.activePiece == null)
            {
                this.SelectedSquare = squareViewModel;
            }

            // Only allow selecting on squares with active piece
            if (squareViewModel.activePiece != null)
            {
                // Allow highlighting and unhighlighting of selected square
                if (this.SelectedSquare.Selected)
                {
                    squareViewModel.Select(false);
                    this.SelectedSquare = null;
                }
                else
                {
                    squareViewModel.Select(true);
                }
            }


            if (this.SelectedSquare != squareViewModel && this.SelectedSquare != null)
            {
                squareViewModel.activePiece = this.SelectedSquare.activePiece;
                this.SelectedSquare.Select(false);
                this.SelectedSquare.activePiece = null;
            }


        }
        private void RotatePiece(Rotate rotation)
        {
            this.SelectedSquare.activePiece?.RotatePiece(rotation);
            
        }


    }
}
