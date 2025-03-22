using KhetV4.Core.Enums;
using KhetV4.Core.StaticClasses;
using Stylet;

namespace KhetV4.MVVM.ViewModels
{
    public class PieceViewModel : Screen
    {
        public int Rotation { get; set; }

        public string ImagePath { get; set; }

        private double _opacity;
        public double Opacity { get => _opacity; set => SetAndNotify(ref _opacity, value); }

        public PieceViewModel(Piece piece, Orientation orientation, Player player)
        {
            Opacity = Mappings.OpacityLevel.Normal;
            ImagePath = Mappings.PieceFileName[(player, piece)];
            Rotation = Mappings.Rotation[orientation];

        }

        public PieceViewModel(Piece piece, Player player)
        {
            Opacity = Mappings.OpacityLevel.Normal;
            ImagePath = Mappings.PieceFileName[(player, piece)];
        }

        public void LeftClick()
        {

        }

        public void MouseEnter()
        {
            Opacity = Mappings.OpacityLevel.Highlighted;
        }

        public void MouseLeave()
        {
            Opacity = Mappings.OpacityLevel.Normal;
        }
    }
}