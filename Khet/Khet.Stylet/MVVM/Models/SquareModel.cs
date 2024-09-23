using Khet.Stylet.MVVM.Models.MyPieces;
using Khet.Stylet.MVVM.Models.MyPieces.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Stylet.MVVM.Models
{
    public class SquareModel
    {
        public Piece activePiece { get; set; }

        public SquareModel()
        {

        }

        private Piece RotatePiece(Rotate rotation)
        {
            if (activePiece != null)
            {

                activePiece.Rotate(rotation);
            }
            else
            {
                return activePiece;
            }

        }

    }
}
