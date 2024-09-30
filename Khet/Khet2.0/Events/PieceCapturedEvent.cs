using Khet2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet2._0.Events
{
    public class PieceCapturedEvent
    {
        public IPiece piece;
        public PieceCapturedEvent(IPiece piece)
        {
            this.piece = piece;
        }
    }
}
