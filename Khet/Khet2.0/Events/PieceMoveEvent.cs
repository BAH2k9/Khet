namespace Khet2._0.Events
{
    public class PieceMoveEvent
    {
        public int playerTurn;

        public PieceMoveEvent(int playerTurn)
        {
            this.playerTurn = playerTurn;
        }
    }
}