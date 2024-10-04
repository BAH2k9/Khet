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

        public BoardViewModel(BoardUpdateService boardUpdater)
        {
            this.rows = 8;
            this.cols = 10;
            boardUpdater.GiveReference(this.Squares);
            boardUpdater.CreateSquares(this.rows, this.cols);
            boardUpdater.SetPieces();
        }
    }
}
