using KhetV4.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV4.Core.StaticClasses
{
    public static class Mappings
    {
        static readonly string basePath = "../../Assets/Pieces/";
        public static Dictionary<(Player, Piece), string> PieceFileName { get; set; } = new()
        {

            { (Player.P1, Piece.Pyramid), basePath + "PyramidSilver.png" },
            { (Player.P2, Piece.Pyramid), basePath +"PyramidRed.png" },

            { (Player.P1, Piece.Djed), basePath +"DjedSilver.png" },
            { (Player.P2, Piece.Djed), basePath +"DjedRed.png" },

            { (Player.P1, Piece.Obelisk), basePath +"DjedRed.png" },
            { (Player.P2, Piece.Obelisk), basePath +"DjedRed.png" },

            { (Player.P1, Piece.Pharaoh),basePath + "DjedRed.png" },
            { (Player.P2, Piece.Pharaoh),basePath + "DjedRed.png" },

        };

        public static Dictionary<Orientation, int> Rotation { get; set; } = new()
        {
            { Orientation.NW, 0 },
            { Orientation.NE, 90 },
            { Orientation.SE, 180 },
            { Orientation.SW, 270 }
        };

        public static (double Highlighted, double Normal) OpacityLevel { get; set; } = (1, 0.7);

    }
}
