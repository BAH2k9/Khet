using KhetV3.Interfaces;
using KhetV3.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.MVVM.Models
{
    public class DjedShiftMove : IMove
    {
        public DjedViewModel Djed;
        public IPiece piece;

        public DjedShiftMove(DjedViewModel Djed, IPiece piece)
        {
            this.Djed = Djed;
            this.piece = piece;
        }

    }
}
