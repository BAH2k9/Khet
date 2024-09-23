using Khet.Stylet.MVVM.Models.MyPieces.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Stylet.MVVM.Models.MyPieces
{
    public abstract class Piece : IPiece
    {
        public int player { get; set; }
        public (int x, int y) position { get; set; }
        public Orientations orientation { get; set; }

        protected Piece(int player, (int x, int y) position, Orientations orientation)
        {
            this.player = player;
            this.position = position;
            this.orientation = orientation;
        }

        virtual public void Rotate(Rotate rotation)
        {
            throw new NotImplementedException();
            // throw new PieceRotationException("Piece cannot be rotated!");
        }
    }

}
