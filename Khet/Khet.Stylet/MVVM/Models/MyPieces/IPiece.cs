using System.Collections.Generic;

namespace Khet.Stylet.MVVM.Models.MyPieces
{
    public interface IPiece
    {
        public int player { get; set; }

        public (int x, int y) position { get; set; }

        public Enum.Orientations orientation { get; set; }

        public class Piece(int player, (int x, int y) position, Enum.Orientations orientation)
        {
            this.player = player;
            this.position = position;
                this.orientation = orientation;
        }

        public PieceInfo GetPieceInfo()
        {
            return new PieceInfo
            {
                orientation = orientation,
                player = player,
                position = position
            };
        }

    }


}
