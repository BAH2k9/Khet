using Khet.Wpf.AbstractClasses;
using Khet.Wpf.Enums;
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
            return Direction.Kill;
        }

    }
}
