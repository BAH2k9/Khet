using Khet.Stylet.MVVM.Models.MyPieces.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Stylet.MVVM.Models.MyPieces
{
    public record PieceInfo
    {
        public int player { get; set; }

        public (int x, int y) position { get; set; }

        public Orientations orientation { get; set; }
    }
}
