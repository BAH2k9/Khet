using Khet2._0.CustomTypes;
using Khet2._0.Events;
using Khet2._0.Interfaces;
using Khet2._0.MVVM.ViewModel;
using Stylet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Khet2._0.MVVM.Models
{
    public class MoveModel : IHandle<SquareClickEvent>, IHandle<PlayerTurnEvent>, IHandle<LaserFireEvent>
    {
        private int playerTurn;
        private SquareViewModel square = null;

        private EventAggregator _eventAggregator;

        private int state = 1;

        private bool pieceAlreadyMoved = false;

        public MoveModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void Handle(SquareClickEvent e)
        {

            if (state == 1)
            {
                if (e.hasPiece && playerTurn == e.square.ActivePiece?.player)
                {
                    square = e.square;
                    square.SelectSquare();
                    state = 2;
                    return;

                }
            }

            if (state == 2)
            {
                if (e.square == square) // Same square clicked twice -> unselect square
                {
                    square.UnselectSquare();
                    square = null;
                    state = 1;
                }
                else                  // Different square clicked -> move piece
                {


                    if (ValidateMovePiece(square, e.square))
                    {
                        MovePiece(square, e.square);
                        square.UnselectSquare();
                        square = null;
                        state = 1;
                    }
                    else // if move pece not allowed
                    {
                        if (e.hasPiece && e.square.ActivePiece is not DjedViewModel)
                        {
                            square.UnselectSquare();
                            e.square.SelectSquare();
                            square = e.square;
                        }
                        else if (e.hasPiece && e.square.ActivePiece is DjedViewModel && e.square.ActivePiece.player == playerTurn)
                        {
                            square.UnselectSquare();
                            e.square.SelectSquare();
                            square = e.square;
                        }
                    }

                }
                return;
            }

        }

        public void Handle(PlayerTurnEvent e)
        {
            if (e.player == 1)
            {
                playerTurn = 1;
            }
            else
            {
                playerTurn = 2;
            }
        }

        private bool ValidateMovePiece(SquareViewModel Old, SquareViewModel New)
        {

            var row_diff = Math.Abs(Old.idx.row - New.idx.row);
            var col_diff = Math.Abs(Old.idx.column - New.idx.column);


            if (row_diff <= 1 && col_diff <= 1)
            {
                if (Old.ActivePiece is DjedViewModel djed)
                {
                    if (New.ActivePiece is not DjedViewModel && New.ActivePiece is not PharaohViewModel)
                    {

                        return true;
                    }

                }

                if (New.ActivePiece == null)
                {
                    return true;
                }


            }
            return false;

        }

        public void MovePiece(SquareViewModel Old, SquareViewModel New)
        {
            if (pieceAlreadyMoved)
            {
                return;
            }
            var temp = New.ActivePiece;
            New.ActivePiece = Old.ActivePiece;
            Old.ActivePiece = temp;

            pieceAlreadyMoved = true;
            _eventAggregator.Publish(new PieceMoveEvent(playerTurn));


        }

        public void Handle(LaserFireEvent message)
        {
            pieceAlreadyMoved = false;
        }
    }


}
