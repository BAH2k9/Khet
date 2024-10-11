namespace KhetV3.MVVM.ViewModels
{
    public class PieceMovedEvent
    {
        public int player { get; set; }

        public PieceMovedEvent(int player)
        {
            this.player = player;
        }
    }
}