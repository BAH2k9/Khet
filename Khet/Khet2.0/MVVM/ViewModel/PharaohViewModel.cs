using Khet2._0.Interfaces;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Khet2._0.MVVM.ViewModel
{
    public class PharaohViewModel : Screen, IPiece
    {
        private Brush _playerColor;
        public Brush playerColor { get => _playerColor; set => SetAndNotify(ref _playerColor, value); }

        public int player { get; set; }
        public PharaohViewModel(int player)
        {
            this.player = player;
            if (player == 1)
            {
                playerColor = Brushes.Silver;
            }
            else
            {
                playerColor = Brushes.Red;
            }
        }
    }
}
