using Khet.Wpf.AbstractClasses;
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
    class ObeliskViewModel : Piece
    {
        private Brush _playerColor;
        public new Brush playerColor 
        {
            get => base.playerColor;
            set => SetProperty(ref base.playerColor, value);
        }
        public ObeliskViewModel(int player)
        {
            SetColor(player);
        }
        public override Direction ResolveLaserDirection(Direction direction)
        {
            return Direction.kill;
        }

    }
}
