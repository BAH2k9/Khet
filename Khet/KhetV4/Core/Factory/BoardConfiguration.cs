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
        static int rows = 8;
        static int cols = 10;



        public static Dictionary<(int, int), SquareViewModel> CreateBoard(int selection)
        {
            var board = CreateSquares();

            switch (selection)
            {
                case 1:
                    DefaultMap(board);
                    break;
                default:
                    break;
            }

            return board;
        }

        private static void DefaultMap(Dictionary<(int, int), SquareViewModel> board)
        {
            board[(1, 1)].PieceViewModel = new PieceViewModel();
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
    }
}
