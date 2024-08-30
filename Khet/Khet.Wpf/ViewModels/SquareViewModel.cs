using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Wpf.ViewModels
{
    public class SquareViewModel : ViewModelBase
    {
        public SquareViewModel? upNeighbour {  get; set; }
        public SquareViewModel? downNeighbour {  get; set; }
        public SquareViewModel? leftNeighbour {  get; set; }
        public SquareViewModel? rightNeighbour {  get; set; }
        public SquareViewModel? nextSquare { get; set; }
        public Piece piece { get; set; }

        private string _text = "";
        public string text { get => _text; set => SetProperty(ref _text, value); }

        public SquareViewModel()
        {
            piece = new Piece() { state = State.dl };

            text = "hi";
        }

        private void FireLaser(directionEnum direction)
        {
            nextSquare.FireLaser(direction);
        }
    }
}
