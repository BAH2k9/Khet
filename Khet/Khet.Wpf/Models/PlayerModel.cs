using Khet.Wpf.AbstractClasses;
using System.Windows.Media;

namespace Khet.Wpf.Models
{
    public class Player
    {
        public string name { get; set; }
        public int playerId { get; set; } // Player 1 or Player 2
        public Brush playerColor { get; set; }
        public List<Piece> pieces { get; set; } = new List<Piece>();
        public List<Piece> lostPieces { get; set; } = new List<Piece>();

        public Player(string name, int playerId, Brush playerColor)
        {
            name = name;
            playerId = playerId;
            playerColor = playerColor;
        }
    }

}
