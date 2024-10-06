using KhetV3.MVVM.Models;
using KhetV3.Services;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.MVVM.ViewModels
{
    public class BoardViewModel : Screen
    {
        public BindableCollection<SquareViewModel> Squares { get; set; } = new BindableCollection<SquareViewModel>();

        private int _rows;
        public int rows { get => _rows; set => SetAndNotify(ref _rows, value); }

        private int _cols;
        public int cols { get => _cols; set => SetAndNotify(ref _cols, value); }

        private BoardUpdateService _updateService;
        private SquareFactory _squareFactory;
        private PieceFactory _pieceFactory;

        public BoardViewModel(BoardUpdateService updateService, SquareFactory squareFactory, PieceFactory pieceFactory)
        {
            _updateService = updateService;
            _squareFactory = squareFactory;
            _pieceFactory = pieceFactory;
        }

        public void SetDimensions(int row, int col)
        {
            this.rows = row;
            this.cols = col;
        }

        public void Initialise()
        {
            _squareFactory.CreateSquares(this.rows, this.cols);

            this.Squares = _squareFactory.GetBindableSquares();

            _updateService.SetSquares(_squareFactory.GetSquares());
            _updateService.SetPieces(_pieceFactory.Classic());
        }
    }
}
