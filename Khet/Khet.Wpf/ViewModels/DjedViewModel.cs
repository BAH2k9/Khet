using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Khet.Wpf.ViewModels
{
    public class DjedViewModel : ViewModelBase,  IPiece
    {
        public Djed orientation {  get; set; }
        public int player { get; set; }

        private Brush _playerColor;
        public Brush playerColor { get => _playerColor; set => SetProperty(ref _playerColor, value); }

        private double _controlWidth;
        public double controlWidth 
        {
            get { return _controlWidth; }
            set { _controlWidth = value; Display(); }
        }
        private double _controlHeight { get; set; }
        public double controlHeight
        {
            get { return _controlHeight; }
            set { _controlHeight = value; Display(); }
        }

        public ObservableCollection<double> point1 { get; set; } = [0,0];
        public ObservableCollection<double> point2 { get; set; } = [0,0];



        public DjedViewModel(Djed orientation, int player = 1)
        {
            this.player = player;
            this.orientation = orientation;

            SetColor();
            Display();
        }

        private void SetColor()
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

        private void Display()
        {
            if (this.orientation == Djed.dl)
            {
                point1[0] = 0;
                point1[1] = 0;
                point2[0] = controlWidth;
                point2[1] = controlHeight;
            }
            else
            {
                point1[0] = controlWidth;
                point1[1] = 0;
                point2[0] = 0;
                point2[1] = controlHeight;
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





