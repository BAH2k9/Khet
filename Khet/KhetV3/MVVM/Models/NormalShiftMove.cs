using KhetV3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.MVVM.Models
{
    public class NormalShiftMove : IMove
    {
        public IPiece piece;
        public (int, int) position;

        public NormalShiftMove(IPiece piece, (int, int) position)
        {
            this.piece = piece;
            this.position = position;
        }

    }
}
