using KhetV3.Events;
using KhetV3.Interfaces;
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
    public class ClickService : IHandle<LaserFiredEvent>
    {
        private BoardUpdateService _boardUpdateService;
        private IPiece _storedPiece = null;

        public ClickService(EventAggregator eventAggregator, BoardUpdateService boardUpdateService)
        {
            eventAggregator.Subscribe(this);
            _boardUpdateService = boardUpdateService;
        }
        public void Click(IPiece piece)
        {
            if (_storedPiece == null)
            {
                _storedPiece = piece;
                _boardUpdateService.SelectSquare(piece.position);
                Trace.WriteLine("ClickService.PieceClick - Select Piece");
            }
            else if (_storedPiece == piece)
            {
                _boardUpdateService.UnselectSquare(piece.position);
                _storedPiece = null;
                Trace.WriteLine("ClickService.PieceClick - Unselect Square");
            }
            else if (_storedPiece is DjedViewModel djed)
            {
                _boardUpdateService.UnselectSquare(_storedPiece.position);
                _storedPiece = null;
                DjedShift(djed, piece);
            }
            else
            {
                _boardUpdateService.UnselectSquare(_storedPiece.position);
                _boardUpdateService.SelectSquare(piece.position);
                _storedPiece = piece;
                Trace.WriteLine("ClickService.PieceClick - Select New Piece");
            }
        }

        public void Click(SquareViewModel square)
        {
            // Stops Click Square being called when Clicking a Piece
            if (square.ActivePiece == _storedPiece)
            {
                return;
            }
            // Stops Click Square being called if a piece hasnt been selected 
            if (_storedPiece == null)
            {
                return;
            }
            // Stops Pieces from being shifted if the square is occupied
            if (square.ActivePiece != null)
            {
                return;
            }

            NormalShift(_storedPiece, square);

        }

        private void NormalShift(IPiece piece, SquareViewModel square)
        {

            _boardUpdateService.UnselectSquare(piece.position);
            _boardUpdateService.ShiftPiece(piece, square.position);
            _storedPiece = null;

            Trace.WriteLine("ClickService.SquareClick - Move Piece");
        }
        private void DjedShift(DjedViewModel djed, IPiece piece)
        {
            if (piece is PyramidViewModel || piece is ObeliskViewModel)
            {
                _boardUpdateService.ShiftPieces(djed, piece);
                _boardUpdateService.UnselectSquare(djed.position);

                Trace.WriteLine("ClickService.SquareClick - Swapped Djed");
            }
        }

        public void Handle(LaserFiredEvent message)
        {
            if (_storedPiece == null)
            {
                return;
            }

            _boardUpdateService.UnselectSquare(_storedPiece.position);
            _storedPiece = null;

        }
    }
}
