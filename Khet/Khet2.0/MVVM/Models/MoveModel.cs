using Khet2._0.CustomTypes;
using Khet2._0.Enums;
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
    public class MoveModel : IHandle<SquareClickEvent>, IHandle<PlayerChangeEvent>, IHandle<RotateEvent>
    {
        private int playerTurn;
        private SquareViewModel square = null;

        private EventAggregator _eventAggregator;

        private int state = 1;
        private int _playerTurn = 1;

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
                if (e.square.ActivePiece.player == _playerTurn)
                {
                    square = e.square;
                    square.SelectSquare();
                    _eventAggregator.Publish(new PieceSelectedEvent(square.idx)); //This enables squares around the selected piece
                    state = 2;
                    return;

                }
            }

            if (state == 2)
            {
                if (e.square.ActivePiece == square.ActivePiece)
                {
                    square.UnselectSquare();
                    square = null;
                    state = 1;
                    _eventAggregator.Publish(new PieceUnselectedEvent(_playerTurn)); //This disables squares around the selected piece
                    return;
                }

                if (e.square.ActivePiece == null)
                {
                    e.square.ActivePiece = square.ActivePiece;
                    square.UnselectSquare();
                    state = 1;
                    _eventAggregator.Publish(new PieceMovedEvent(_playerTurn, square, e.square));
                    square.ActivePiece = null;
                    return;
                }

                if (square.ActivePiece is DjedViewModel djed)
                {
                    if (e.square.ActivePiece is PyramidViewModel || e.square.ActivePiece is ObeliskViewModel)
                    {
                        var temp = e.square.ActivePiece;
                        e.square.ActivePiece = square.ActivePiece;
                        square.ActivePiece = temp;
                        square.UnselectSquare();
                        state = 1;
                        _eventAggregator.Publish(new PieceMovedEvent(_playerTurn, square, e.square));
                        return;
                    }
                }
                return;

            }
        }

        public void Handle(PlayerChangeEvent e)
        {
            _playerTurn = e.player;
        }

        public void Handle(RotateEvent e)
        {
            if (this.square?.ActivePiece != null && this.square.IsEnabled)
            {
                if (this.square.ActivePiece is IRotatable rotatablePiece)
                {
                    rotatablePiece.Rotate(e.direction);
                    _eventAggregator.Publish(new PieceRotatedEvent());
                }
            }
        }
    }


}
