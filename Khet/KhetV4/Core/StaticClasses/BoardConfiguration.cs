using KhetV4.Core.Enums;
using KhetV4.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV4.Core.Factory
{
    public static class BoardConfiguration
    {
        static readonly int rows = 8;
        static readonly int cols = 10;

        public static Dictionary<(int, int), SquareViewModel> CreateBoard(int selection)
        {
            var board = CreateSquares();

            switch (selection)
            {
                case 1:
                    DefaultMap(board);
                    break;
                default:
                    throw new ArgumentException("Invalid selection");
            }

            return board;
        }
        static Dictionary<(int, int), SquareViewModel> CreateSquares()
        {
            var board = new Dictionary<(int, int), SquareViewModel>();

            for (int i = 0; i < rows * cols; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board.Add((i, j), new SquareViewModel());
                }
            }

            return board;

        }
        private static void DefaultMap(Dictionary<(int, int), SquareViewModel> board)
        {
            board[(3, 0)].PieceViewModel = new PieceViewModel(Piece.Pyramid, Orientation.NE, Player.P2);
            board[(4, 0)].PieceViewModel = new PieceViewModel(Piece.Pyramid, Orientation.SE, Player.P2);

            board[(1, 2)].PieceViewModel = new PieceViewModel(Piece.Pyramid, Orientation.SW, Player.P2);
            board[(3, 2)].PieceViewModel = new PieceViewModel(Piece.Pyramid, Orientation.SW, Player.P1);
            board[(4, 2)].PieceViewModel = new PieceViewModel(Piece.Pyramid, Orientation.NW, Player.P1);
            board[(7, 2)].PieceViewModel = new PieceViewModel(Piece.Pyramid, Orientation.NW, Player.P1);

            board[(2, 3)].PieceViewModel = new PieceViewModel(Piece.Pyramid, Orientation.NW, Player.P1);
            board[(7, 3)].PieceViewModel = new PieceViewModel(Piece.Obelisk, Player.P1);

            board[(0, 4)].PieceViewModel = new PieceViewModel(Piece.Obelisk, Player.P2);
            board[(3, 4)].PieceViewModel = new PieceViewModel(Piece.Djed, Orientation.NE, Player.P2);
            board[(4, 4)].PieceViewModel = new PieceViewModel(Piece.Djed, Orientation.NW, Player.P1);
            board[(7, 4)].PieceViewModel = new PieceViewModel(Piece.Pharaoh, Player.P1);

            board[(0, 5)].PieceViewModel = new PieceViewModel(Piece.Pharaoh, Player.P2);
            board[(3, 5)].PieceViewModel = new PieceViewModel(Piece.Djed, Orientation.NW, Player.P2);
            board[(4, 5)].PieceViewModel = new PieceViewModel(Piece.Djed, Orientation.NE, Player.P1);
            board[(7, 5)].PieceViewModel = new PieceViewModel(Piece.Obelisk, Player.P1);

            board[(0, 6)].PieceViewModel = new PieceViewModel(Piece.Obelisk, Player.P2);
            board[(5, 6)].PieceViewModel = new PieceViewModel(Piece.Pyramid, Orientation.SE, Player.P2);

            board[(0, 7)].PieceViewModel = new PieceViewModel(Piece.Pyramid, Orientation.SE, Player.P2);
            board[(3, 7)].PieceViewModel = new PieceViewModel(Piece.Pyramid, Orientation.SE, Player.P2);
            board[(4, 7)].PieceViewModel = new PieceViewModel(Piece.Pyramid, Orientation.NE, Player.P2);
            board[(6, 7)].PieceViewModel = new PieceViewModel(Piece.Pyramid, Orientation.NE, Player.P1);

            board[(3, 9)].PieceViewModel = new PieceViewModel(Piece.Pyramid, Orientation.NW, Player.P1);
            board[(4, 9)].PieceViewModel = new PieceViewModel(Piece.Pyramid, Orientation.SW, Player.P1);
        }
    }
}
