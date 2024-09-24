using Khet2._0.Interfaces;
using Stylet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet2._0.MVVM.ViewModel
{
    public class SquareViewModel : Screen
    {
        private LaserViewModel _ActiveLaser;
        public LaserViewModel ActiveLaser { get => _ActiveLaser; set => SetAndNotify(ref _ActiveLaser, value); }

        private IPiece _ActivePiece;
        public IPiece ActivePiece { get => _ActivePiece; set => SetAndNotify(ref _ActivePiece, value); }

        public SquareViewModel()
        {

        }

        public void ExecuteMouseDown()
        {
            Trace.WriteLine("SquareClicked!");
        }
    }
}
