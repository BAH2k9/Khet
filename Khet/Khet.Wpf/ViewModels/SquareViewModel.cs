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

        private ViewModelBase _activeLaser;
        public ViewModelBase activeLaser { get => _activeLaser; set => SetProperty(ref _activeLaser, value); }

        public SquareViewModel()
        {
            //piece = new Piece() { state = State.dl };



        }

        public void SetLaser()
        {
            if (rightNeighbour == null)
            {
                activeLaser = new VerticalBeamViewModel();
            }

            if (downNeighbour == null)
            {
                activeLaser = new HorizontalBeamViewModel();
            }
        }

        //public static SquareViewModel Make(SquareViewModel up, SquareViewModel down, SquareViewModel left, SquareViewModel right)
        //{
        //    return new SquareViewModel()
        //    {
        //        upNeighbour = up,
        //        downNeighbour = down,
        //        leftNeighbour = left,
        //        rightNeighbour = right,
        //    };
        //}
    }
}
