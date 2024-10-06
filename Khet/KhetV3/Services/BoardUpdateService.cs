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
        private Dictionary<(int, int), SquareViewModel> _squareDictionary;
        private Dictionary<(int, int), IPiece> _pieceDictionary;

        public BoardUpdateService()
        {

        }

        public void SetSquares(Dictionary<(int, int), SquareViewModel> Squares)
        {
            _squareDictionary = Squares;
        }

        public void SetPieces(Dictionary<(int, int), IPiece> pieces)
        {
            _pieceDictionary = pieces;

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

        public Dictionary<(int, int), IPiece> GetPieceInfo()
        {
            return _pieceDictionary;
        }

        public async Task DisplayLaser((int row, int col) squarePosition, (LaserPosition, LaserPosition) laserPosition)
        {
            Trace.WriteLine($"BoardUpdater.DisplayLaser at row: {squarePosition.row}, col: {squarePosition.col} with Laser: {laserPosition} ");

            _squareDictionary[squarePosition].ActiveLaser = new LaserViewModel(laserPosition); ;
            await _squareDictionary[squarePosition].ActiveLaser.Animate();
            _squareDictionary[squarePosition].ActiveLaser.AnimateRemoveLaser();
        }

        public void SelectSquare((int, int) position)
        {
            _squareDictionary[position].Select(true);
        }

    }
}
