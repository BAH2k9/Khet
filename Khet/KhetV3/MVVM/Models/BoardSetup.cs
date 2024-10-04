using Khet3.Enums;
using KhetV3.Interfaces;
using KhetV3.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.MVVM.Models
{
    public static class BoardSetup
    {

        public static Dictionary<(int, int), IPiece> Classic = new Dictionary<(int, int), IPiece>
        {
            {(3, 0), new PyramidViewModel(Orientations.NE, 2) },
            {(4, 0), new PyramidViewModel(Orientations.SE, 2) },

            {(1, 2), new PyramidViewModel(Orientations.SW, 2) },
            {(3, 2), new PyramidViewModel(Orientations.SW, 1) },
            {(4, 2), new PyramidViewModel(Orientations.NW, 1) },
            {(7, 2), new PyramidViewModel(Orientations.NW, 1) },

            {(2, 3), new PyramidViewModel(Orientations.NW, 1) },
            {(7, 3), new ObeliskViewModel(1) },

            {(0, 4), new ObeliskViewModel(2) },
            {(3, 4), new DjedViewModel(Orientations.NE, 2) },
            {(4, 4), new DjedViewModel(Orientations.NW, 1) },
            {(7, 4), new PharaohViewModel(1) },

            {(0, 5), new PharaohViewModel(2) },
            {(3, 5), new DjedViewModel(Orientations.NW, 2) },
            {(4, 5), new DjedViewModel(Orientations.NE, 1) },
            {(7, 5), new ObeliskViewModel(1) },

            {(0, 6), new ObeliskViewModel(2) },
            {(5, 6), new PyramidViewModel(Orientations.SE, 2) },

            {(0, 7), new PyramidViewModel(Orientations.SE, 2) },
            {(3, 7), new PyramidViewModel(Orientations.SE, 2) },
            {(4, 7), new PyramidViewModel(Orientations.NE, 2) },
            {(6, 7), new PyramidViewModel(Orientations.NE, 1) },

            {(3, 9), new PyramidViewModel(Orientations.NW, 1) },
            {(4, 9), new PyramidViewModel(Orientations.SW, 1) },


        };
    }
}
