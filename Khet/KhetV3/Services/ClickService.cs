using KhetV3.Interfaces;
using KhetV3.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.Services
{
    public class ClickService
    {
        private BoardUpdateService _boardUpdateService;
        private IPiece _storedPiece;
        private SquareViewModel _storedSquareViewModel;

        public ClickService(BoardUpdateService boardUpdateService)
        {
            _boardUpdateService = boardUpdateService;
        }
        public void Click(IPiece piece)
        {
            Trace.WriteLine("ClickService.PieceClick");
            if (_storedPiece == null)
            {
                _storedPiece = piece;
                _boardUpdateService.SelectSquare(piece.position);

            }
        }

        public void Click(SquareViewModel squareViewModel)
        {
            Trace.WriteLine("ClickService.SquareClick");

            if (_storedSquareViewModel == null)
            {
                _storedSquareViewModel = squareViewModel;
            }
        }
    }
}
