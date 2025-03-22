using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV4.MVVM.ViewModels
{
    public class SquareViewModel : Screen
    {
        PieceViewModel _pieceViewModel;
        public PieceViewModel PieceViewModel { get => _pieceViewModel; set => SetAndNotify(ref _pieceViewModel, value); }

        public SquareViewModel()
        {

        }
    }
}
