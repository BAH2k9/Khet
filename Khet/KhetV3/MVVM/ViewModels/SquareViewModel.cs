using KhetV3.Interfaces;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KhetV3.MVVM.ViewModels
{
    public class SquareViewModel : Screen
    {
        public IPiece ActivePiece { get; set; }
        private LaserViewModel _ActiveLaser;
        public LaserViewModel ActiveLaser { get => _ActiveLaser; set => SetAndNotify(ref _ActiveLaser, value); }

        private Brush _highlight = Brushes.Transparent;
        public Brush highlight { get => _highlight; set => SetAndNotify(ref _highlight, value); }
        public SquareViewModel()
        {

        }
    }
}
