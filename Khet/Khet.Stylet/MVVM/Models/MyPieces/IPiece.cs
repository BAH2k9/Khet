using Khet.Stylet.MVVM.Models.MyPieces.Enum;
using System.Collections.Generic;

namespace Khet.Stylet.MVVM.Models.MyPieces
{
    public interface IPiece
    {
        public int player { get; set; }

        public (int x, int y) position { get; set; }

        public Orientations orientation { get; set; }

        public PieceInfo GetPieceInfo()
        {
            return new PieceInfo
            {
                orientation = orientation,
                player = player,
                position = position
            };
        }

        public abstract void Rotate(Rotate rotation);

    }


}
