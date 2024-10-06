using Khet3.Enums;
using KhetV3.Interfaces;
using KhetV3.MVVM.ViewModels;
using KhetV3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.MVVM.Models
{
    public class PieceFactory
    {
        private ClickService _clickService;
        public PieceFactory(ClickService clickService)
        {
            _clickService = clickService;
        }
        public Dictionary<(int, int), IPiece> Classic()
        {
            var pieces = new Dictionary<(int, int), IPiece>
            {
                {(3, 0), new PyramidViewModel(_clickService, Orientations.NE, 2) },
                {(4, 0), new PyramidViewModel(_clickService, Orientations.SE, 2) },

                {(1, 2), new PyramidViewModel(_clickService, Orientations.SW, 2) },
                {(3, 2), new PyramidViewModel(_clickService, Orientations.SW, 1) },
                {(4, 2), new PyramidViewModel(_clickService, Orientations.NW, 1) },
                {(7, 2), new PyramidViewModel(_clickService, Orientations.NW, 1) },

                {(2, 3), new PyramidViewModel(_clickService, Orientations.NW, 1) },
                {(7, 3), new ObeliskViewModel(_clickService, 1) },

                {(0, 4), new ObeliskViewModel(_clickService, 2) },
                {(3, 4), new DjedViewModel(_clickService, Orientations.NE, 2) },
                {(4, 4), new DjedViewModel(_clickService, Orientations.NW, 1) },
                {(7, 4), new PharaohViewModel(_clickService, 1) },

                {(0, 5), new PharaohViewModel(_clickService, 2) },
                {(3, 5), new DjedViewModel(_clickService, Orientations.NW, 2) },
                {(4, 5), new DjedViewModel(_clickService, Orientations.NE, 1) },
                {(7, 5), new ObeliskViewModel(_clickService, 1) },

                {(0, 6), new ObeliskViewModel(_clickService, 2) },
                {(5, 6), new PyramidViewModel(_clickService, Orientations.SE, 2) },

                {(0, 7), new PyramidViewModel(_clickService, Orientations.SE, 2) },
                {(3, 7), new PyramidViewModel(_clickService, Orientations.SE, 2) },
                {(4, 7), new PyramidViewModel(_clickService, Orientations.NE, 2) },
                {(6, 7), new PyramidViewModel(_clickService, Orientations.NE, 1) },

                {(3, 9), new PyramidViewModel(_clickService, Orientations.NW, 1) },
                {(4, 9), new PyramidViewModel(_clickService, Orientations.SW, 1) },

            };

            foreach (var pieceEntry in pieces)
            {
                var piece = pieceEntry.Value;
                var position = pieceEntry.Key;

                piece.SetPosition(position);
            }

            return pieces;
        }

    }
}
