using Khet.Stylet.MVVM.Models.MyPieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Khet.Stylet.MVVM.Models
{
    public class BoardConfigurationModel
    {
        public BoardConfigurationModel()
        {
            var pieceInfo = new PieceInfo() { orientation = new DjedOrientation() };


            var activePiece = new Djed(pieceInfo);
        }
    }
}
