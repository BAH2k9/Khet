﻿using Khet3.Enums;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KhetV3.Services
{
    public class BoardUpdateService
    {
        private Dictionary<(int, int), SquareViewModel> _squareDictionary;
        private Dictionary<(int, int), IPiece> _pieceDictionary;
        private IPiece _selectedPiece;
        private HistoryService _historyService;
        private GameRules _gameRules;



        public BoardUpdateService(HistoryService historyService, GameRules gameRules)
        {
            _historyService = historyService;
            _gameRules = gameRules;
        }

        public void SetPlayerRules()
        {
            _gameRules.TurnOn();
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

            _pieceDictionary.Clear();

            foreach (var entry in _squareDictionary)
            {
                var square = entry.Value;
                var position = entry.Key;
                if (square.ActivePiece != null)
                {
                    _pieceDictionary[position] = square.ActivePiece;
                }
            }

            return _pieceDictionary;
        }

        public async Task DisplayLaser((int row, int col) squarePosition, (LaserPosition, LaserPosition) laserPosition)
        {
            Trace.WriteLine($"BoardUpdater.DisplayLaser at row: {squarePosition.row}, col: {squarePosition.col} with Laser: {laserPosition} ");

            _squareDictionary[squarePosition].ActiveLaser = new LaserViewModel(laserPosition);
            await _squareDictionary[squarePosition].ActiveLaser.Animate();
            _squareDictionary[squarePosition].ActiveLaser.AnimateRemoveLaser();

        }

        public void SelectSquare((int, int) position)
        {
            if (_gameRules.CanSelect(_squareDictionary[position]))
            {
                _squareDictionary[position].Select(true);
                _selectedPiece = _squareDictionary[position].ActivePiece;
            }

        }
        public void UnselectSquare((int, int) position)
        {
            _squareDictionary[position].Select(false);
            _selectedPiece = null;
        }


        public void ShiftPiece(IPiece piece, (int, int) position)
        {
            var squarePlayer = _squareDictionary[position].player;

            if (_gameRules.CanShift(piece, position, squarePlayer))
            {
                _historyService.AddShift(piece.position, position);

                _squareDictionary[piece.position].ActivePiece = null;
                _squareDictionary[position].ActivePiece = piece;

                piece.position = position;

            }


        }

        public void ShiftPieces(DjedViewModel djed, IPiece piece)
        {
            var squarePlayer = _squareDictionary[piece.position].player;

            if (_gameRules.CanShift(djed, piece.position, squarePlayer))
            {
                _historyService.AddShift(djed.position, piece.position);

                _squareDictionary[djed.position].ActivePiece = piece;
                _squareDictionary[piece.position].ActivePiece = djed;

                var temp = piece.position;
                piece.position = djed.position;
                djed.position = temp;


            }

        }

        public void RotateSelectedPiece(Key key)
        {
            if (_selectedPiece == null)
            {
                return;
            }

            if (_gameRules.CanRotate())
            {
                if (_selectedPiece is IRotatable rotatablePiece)
                {
                    var oldOrientation = rotatablePiece.orientation;

                    var newOrientation = rotatablePiece.Rotate(key);

                    _historyService.AddRotate(rotatablePiece, oldOrientation, newOrientation);
                }

                UnselectSquare(_selectedPiece.position);
                _selectedPiece = null;



            }

        }

        public void PieceHit((int row, int col) position)
        {
            _squareDictionary[position].ActivePiece = null;
        }

        public void UndoMove()
        {

            if (_historyService.MostRecentMoveType == MoveType.Shift)
            {
                (var oldPos, var newPos) = _historyService.GetLastShift();

                IPiece? oldPiece = _squareDictionary[oldPos].ActivePiece;
                IPiece newPiece = _squareDictionary[newPos].ActivePiece;


                if (oldPiece != null) //Djed Swap
                {
                    oldPiece.position = newPos;
                    newPiece.position = oldPos;

                    _squareDictionary[oldPos].ActivePiece = newPiece;
                    _squareDictionary[newPos].ActivePiece = oldPiece;
                }
                else
                {
                    newPiece.position = oldPos;

                    _squareDictionary[oldPos].ActivePiece = newPiece;
                    _squareDictionary[newPos].ActivePiece = null;
                }
            }
            else if (_historyService.MostRecentMoveType == MoveType.Rotate)
            {
                (var piece, var startOrientation, var endOrientation) = _historyService.GetLastRotation();

                piece.SetOrientation(startOrientation);

            }







        }

    }
}
