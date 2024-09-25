using Khet2._0.CustomTypes;
using Khet2._0.Events;
using Khet2._0.MVVM.ViewModel;
using Stylet;
using System;
using System.Collections.Generic;

namespace Khet2._0.MVVM.Models
{
    public class MoveModel : IHandle<SquareClickEvent>
    {
        //private TwoElementList<SquareViewModel> clickedSquares = new TwoElementList<SquareViewModel>();

        private SquareViewModel square = null;

        private EventAggregator _eventAggregator;

        private int state = 1;

        public MoveModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void Handle(SquareClickEvent e)
        {
            if (state == 1)
            {
                if (e.hasPiece)
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

                    if (movePiece(square, e.square))
                    {
                        square.UnselectSquare();
                        square = null;
                        state = 1;
                    }
                    else
                    {
                        square.UnselectSquare();
                        e.square.SelectSquare();
                        square = e.square;
                    }

                }
                return;
            }

        }

        private bool movePiece(SquareViewModel Old, SquareViewModel New)
        {
            var row_diff = Math.Abs(Old.idx.row - New.idx.row);
            var col_diff = Math.Abs(Old.idx.column - New.idx.column);


            if (row_diff <= 1 && col_diff <= 1)
            {
                if (Old.ActivePiece is DjedViewModel djed)
                {
                    if (New.ActivePiece is not DjedViewModel && New.ActivePiece is not PharaohViewModel)
                    {
                        var temp = New.ActivePiece;
                        New.ActivePiece = Old.ActivePiece;
                        Old.ActivePiece = temp;
                        return true;
                    }

                }

                if (New.ActivePiece == null)
                {
                    New.ActivePiece = Old.ActivePiece;
                    Old.ActivePiece = null;
                    return true;
                }


            }
            return false;

        }

    }
}
