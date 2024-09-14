using Khet.Wpf.AbstractClasses;
using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace Khet.Wpf.ViewModels
{
    public class DjedViewModel : Piece
    {

        private Djed _orientation;
        public Djed orientation
        {
            get { return _orientation; }
            set { _orientation = value; SetOrientation(); }
        }

        public new Brush playerColor
        {
            get => base.playerColor;
            set => SetProperty(ref base.playerColor, value);
        }
        private double _controlWidth;
        public double controlWidth 
        {
            get { return _controlWidth; }
            set { _controlWidth = value; SetOrientation(); }
        }
        private double _controlHeight { get; set; }
        public double controlHeight
        {
            get { return _controlHeight; }
            set { _controlHeight = value; SetOrientation(); }
        }

        public ObservableCollection<double> point1 { get; set; } = [0,0];
        public ObservableCollection<double> point2 { get; set; } = [0,0];



        public DjedViewModel(Djed orientation, int player = 1)
        {
            this.orientation = orientation;

            SetColor(player);
            SetOrientation();
        }


        private void SetOrientation()
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

        

        public override Direction ResolveLaserDirection(Direction inDirection)
        {

            var input = Tuple.Create(inDirection, this.orientation);
            var outDirection = Mappings.DjedDirection[input];

            return outDirection;

        }

        public override void RotatePiece(Rotate rotation)
        {
            // Only two states so can just switch state for either rotation
            if (orientation == Djed.dl)
            {
                orientation = Djed.dr; 
            }
            else
            {
                orientation = Djed.dl;
            }
 
        }
        
    }
}





