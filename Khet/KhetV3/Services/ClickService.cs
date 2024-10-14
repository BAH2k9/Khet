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
    public class ClickService : IHandle<LaserFiredEvent>, IHandle<UndoMoveEvent>, IHandle<NewGameEvent>
    {
        private BoardUpdateService _boardUpdateService;
        private IPiece _previouslyClickedPiece = null;

        public ClickService(EventAggregator eventAggregator, BoardUpdateService boardUpdateService)
        {
            eventAggregator.Subscribe(this);
            _boardUpdateService = boardUpdateService;
        }
        public void Click(IPiece piece)
        {
            if (_previouslyClickedPiece == null)
            {
                _previouslyClickedPiece = piece;
                _boardUpdateService.SelectSquare(piece.position);
                Trace.WriteLine("ClickService.PieceClick - Select Piece");
            }
            else if (_previouslyClickedPiece == piece)
            {
                _boardUpdateService.UnselectSquare(piece.position);
                _previouslyClickedPiece = null;
                Trace.WriteLine("ClickService.PieceClick - Unselect Square");
            }
            else if (_previouslyClickedPiece is DjedViewModel djed)
            {
                _boardUpdateService.UnselectSquare(_previouslyClickedPiece.position);
                _previouslyClickedPiece = null;
                DjedShift(djed, piece);
            }
            else
            {
                _boardUpdateService.UnselectSquare(_previouslyClickedPiece.position);
                _boardUpdateService.SelectSquare(piece.position);
                _previouslyClickedPiece = piece;
                Trace.WriteLine("ClickService.PieceClick - Select New Piece");
            }
        }

        public void Click(SquareViewModel square)
        {
            // Stops Click Square being called when Clicking a Piece
            if (square.ActivePiece == _previouslyClickedPiece)
            {
                return;
            }
            // Stops Click Square being called if a piece hasnt been selected 
            if (_previouslyClickedPiece == null)
            {
                return;
            }
            // Stops Pieces from being shifted if the square is occupied
            if (square.ActivePiece != null)
            {
                return;
            }

            NormalShift(_previouslyClickedPiece, square);

        }

        private void NormalShift(IPiece piece, SquareViewModel square)
        {

            _boardUpdateService.UnselectSquare(piece.position);
            _boardUpdateService.ShiftPiece(piece, square.position);

            _previouslyClickedPiece = null;

            Trace.WriteLine("ClickService.SquareClick - Move Piece");
        }
        private void DjedShift(DjedViewModel djed, IPiece piece)
        {
            if (piece is PyramidViewModel || piece is ObeliskViewModel)
            {
                _boardUpdateService.ShiftPieces(djed, piece);
                _boardUpdateService.UnselectSquare(djed.position);

                _previouslyClickedPiece = null;

                Trace.WriteLine("ClickService.SquareClick - Swapped Djed");
            }
        }

        public void Handle(LaserFiredEvent message)
        {
            if (_previouslyClickedPiece == null)
            {
                return;
            }

            _boardUpdateService.UnselectSquare(_previouslyClickedPiece.position);

            _previouslyClickedPiece = null;

        }

        public void Handle(UndoMoveEvent message)
        {
            _previouslyClickedPiece = null;
        }

        public void RotationOccured()
        {
            _previouslyClickedPiece = null;
        }

        public void Handle(NewGameEvent message)
        {
            _previouslyClickedPiece = null;
        }
    }
}
