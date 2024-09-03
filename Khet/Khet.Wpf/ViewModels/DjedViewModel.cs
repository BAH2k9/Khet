using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Interfaces;

namespace Khet.Wpf.ViewModels
{
    public class DjedViewModel : ViewModelBase,  IPiece
    {
        public Djed orientation {  get; set; }

        private string _rotationAngle = "0";
        public string rotationAngle { get => _rotationAngle; set => SetProperty(ref _rotationAngle, value); }


        public DjedViewModel(Djed orientation)
        {

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







// Used to live in ResolveLaserDirection but has been replaced with a mapping
//switch (this.orientation)
//{
//    case Djed.dl:
//        if (inDirection == Direction.down)
//        {
//            return Direction.left;
//        }
//        else if (inDirection == Direction.right)
//        {
//            return Direction.up;
//        }
//        else if (inDirection == Direction.left)
//        {
//            return Direction.down;
//        }
//        else // (inDirection == Direction.up)
//        {
//            return Direction.right;
//        }

//    case Djed.dr:
//        if (inDirection == Direction.down)
//        {
//            return Direction.right;
//        }
//        else if (inDirection == Direction.right)
//        {
//            return Direction.down;
//        }
//        else if (inDirection == Direction.left)
//        {
//            return Direction.up;
//        }
//        else // (inDirection == Direction.up)
//        {
//            return Direction.left;
//        }                                
//}