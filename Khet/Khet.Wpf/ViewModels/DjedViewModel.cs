using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Interfaces;
using System.Windows.Media;

namespace Khet.Wpf.ViewModels
{
    public class DjedViewModel : ViewModelBase,  IPiece
    {
        public Djed orientation {  get; set; }
        public int player { get; set; }

        private string _rotationAngle = "0";
        public string rotationAngle { get => _rotationAngle; set => SetProperty(ref _rotationAngle, value); }

        private Brush _playerColor;
        public Brush playerColor { get => _playerColor; set => SetProperty(ref _playerColor, value); }

        public DjedViewModel(Djed orientation, int player = 1)
        {
            this.player = player;
            this.orientation = orientation;
            Display();
        }

        private void Display()
        {
            if (this.orientation == Djed.dl)
            {
                rotationAngle = "0";
            }
            else
            {
                rotationAngle = "90";
            }

            if (player == 1)
            {
                playerColor = Brushes.Silver;
            }
            else if (player == 2)
            {
                playerColor = Brushes.Red;
            }


        }

        public Direction ResolveLaserDirection(Direction inDirection)
        {

            var input = Tuple.Create(inDirection, this.orientation);
            var outDirection = Mappings.DjedDirection[input];

            return outDirection;

        }

        public void ClearDisplay()
        {
            
        }
    }
}





