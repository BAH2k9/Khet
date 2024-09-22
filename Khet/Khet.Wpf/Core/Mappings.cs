using Khet.Wpf.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Wpf.Core
{
    public static class Mappings
    {
        public static readonly Dictionary<Tuple<Direction, Djed>, Direction> DjedDirection = new Dictionary<Tuple<Direction, Djed>, Direction>
        {
            {Tuple.Create(Direction.Up, Djed.DL), Direction.Right},
            {Tuple.Create(Direction.Up, Djed.DR), Direction.Left},

            {Tuple.Create(Direction.Down, Djed.DL), Direction.Left},
            {Tuple.Create(Direction.Down, Djed.DR), Direction.Right},

            {Tuple.Create(Direction.Left, Djed.DL), Direction.Down},
            {Tuple.Create(Direction.Left, Djed.DR), Direction.Up},

            {Tuple.Create(Direction.Right, Djed.DL), Direction.Up},
            {Tuple.Create(Direction.Right, Djed.DR), Direction.Down},
        };


        public static readonly Dictionary<Tuple<Direction, Pyramid>, Direction> PyramidDirection = new Dictionary<Tuple<Direction, Pyramid>, Direction>
        {
            {Tuple.Create(Direction.Up, Pyramid.TL), Direction.Kill},
            {Tuple.Create(Direction.Up, Pyramid.TR), Direction.Kill},
            {Tuple.Create(Direction.Up, Pyramid.BL), Direction.Right},
            {Tuple.Create(Direction.Up, Pyramid.BR), Direction.Left},

            {Tuple.Create(Direction.Down, Pyramid.TL), Direction.Right},
            {Tuple.Create(Direction.Down, Pyramid.TR), Direction.Left},
            {Tuple.Create(Direction.Down, Pyramid.BL), Direction.Kill},
            {Tuple.Create(Direction.Down, Pyramid.BR), Direction.Kill},

            {Tuple.Create(Direction.Left, Pyramid.TL), Direction.Kill},
            {Tuple.Create(Direction.Left, Pyramid.TR), Direction.Down},
            {Tuple.Create(Direction.Left, Pyramid.BL), Direction.Kill},
            {Tuple.Create(Direction.Left, Pyramid.BR), Direction.Up},

            {Tuple.Create(Direction.Right, Pyramid.TL), Direction.Down},
            {Tuple.Create(Direction.Right, Pyramid.TR), Direction.Kill},
            {Tuple.Create(Direction.Right, Pyramid.BL), Direction.Up},
            {Tuple.Create(Direction.Right, Pyramid.BR), Direction.Kill},
        };



    }

}
