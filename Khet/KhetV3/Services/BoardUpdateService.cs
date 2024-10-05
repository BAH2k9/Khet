using Khet3.Enums;
using KhetV3.Enums;
using KhetV3.Interfaces;
using KhetV3.MVVM.Models;
using KhetV3.MVVM.ViewModels;
using Stylet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.Services
{
    public class BoardUpdateService
    {
        private BindableCollection<SquareViewModel> _squares;
        private Dictionary<(int, int), SquareViewModel> _squareDictionary { get; set; } = new Dictionary<(int, int), SquareViewModel>();

        public Dictionary<(int, int), IPiece> _pieceDictionary { get; set; } = new Dictionary<(int, int), IPiece> { };

        private int _rows;
        private int _columns;
        public BoardUpdateService()
        {
            _pieceDictionary = BoardSetup.Classic;
        }

        public void GiveReference(BindableCollection<SquareViewModel> Squares)
        {
            _squares = Squares;
        }

        public void CreateSquares(int rows, int cols)
        {
            _rows = rows;
            _columns = cols;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var square = new SquareViewModel();
                    _squares.Add(square);
                    _squareDictionary[(row, col)] = square;
                }
            }
        }

        public void SetPieces()
        {
            foreach (var pieceEntry in _pieceDictionary)
            {
                var position = pieceEntry.Key; // (row, col)
                var piece = pieceEntry.Value;

                if (_squareDictionary.TryGetValue(position, out var squareViewModel))
                {
                    squareViewModel.ActivePiece = piece;
                }
            }
        }

        public async Task DisplayLaser((int row, int col) squarePosition, (LaserPosition, LaserPosition) laserPosition)
        {
            Trace.WriteLine($"BoardUpdater: DisplayLaser at row: {squarePosition.row}, col: {squarePosition.col} with Laser: {laserPosition} ");

            _squareDictionary[squarePosition].ActiveLaser = new LaserViewModel(laserPosition); ;
            await _squareDictionary[squarePosition].ActiveLaser.Animate();
        }

        public bool InBounds((int row, int col) position)
        {
            if (position.row < _rows && position.col < _columns && position.row >= 0 && position.col >= 0)
            {
                return true;
            }

            return false;
        }
    }
}
