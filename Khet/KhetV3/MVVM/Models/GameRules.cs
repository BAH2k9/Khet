using KhetV3.Events;
using KhetV3.Interfaces;
using KhetV3.MVVM.ViewModels;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.MVVM.Models
{
    public class GameRules : IHandle<LaserFiredEvent>
    {
        private bool InPlay = false;
        private int playerTurn = 1;

        public GameRules(EventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
        }
        public void TurnOn()
        {
            InPlay = true;
        }

        public bool CanSelect(SquareViewModel square)
        {
            if (!InPlay)
            {
                return true;
            }

            if (square.ActivePiece.player == playerTurn)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CanShift(IPiece piece, (int row, int col) position)
        {
            if (!InPlay)
            {
                return true;
            }

            if (piece.player != playerTurn)
            {
                return false;
            }

            var rowDiff = Math.Abs(piece.position.row - position.row);
            var colDiff = Math.Abs(piece.position.col - position.col);

            if (rowDiff > 1 || colDiff > 1)
            {
                return false;
            }


            return true;
        }

        public void Handle(LaserFiredEvent message)
        {
            playerTurn = playerTurn switch
            {
                1 => 2,
                2 => 1,
                _ => throw new InvalidOperationException()
            };




        }
    }
}
