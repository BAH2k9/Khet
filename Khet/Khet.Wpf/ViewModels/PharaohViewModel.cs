using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Khet.Wpf.ViewModels
{
    public class PharaohViewModel : ViewModelBase, IPiece
    {
        private Brush _playerColor;
        public Brush playerColor { get => _playerColor; set => SetProperty(ref _playerColor, value); }
        public PharaohViewModel(int player)
        {
            if (player == 1)
            {
                playerColor = Brushes.Silver;
            }
            else if (player == 2)
            {
                playerColor = Brushes.Red;
            }
        }

        public Direction ResolveLaserDirection(Direction direction)
        {
            return Direction.kill;
        }
    }
}
