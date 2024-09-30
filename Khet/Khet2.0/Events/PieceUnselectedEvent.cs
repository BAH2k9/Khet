namespace Khet2._0.Events
{
    public class PieceUnselectedEvent
    {
        public int playerTurn { get; set; }
        public PieceUnselectedEvent(int playerTurn)
        {
            this.playerTurn = playerTurn;
        }
    }
}