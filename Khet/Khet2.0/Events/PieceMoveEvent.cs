namespace Khet2._0.Events
{
    public class PieceMoveEvent
    {
        public int player { get; set; }
        public PieceMoveEvent(int player)
        {
            this.player = player;
        }


    }
}