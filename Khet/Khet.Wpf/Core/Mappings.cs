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
            {Tuple.Create(Direction.up, Djed.dl), Direction.right},
            {Tuple.Create(Direction.up, Djed.dr), Direction.left},

            {Tuple.Create(Direction.down, Djed.dl), Direction.left},
            {Tuple.Create(Direction.down, Djed.dr), Direction.right},

            {Tuple.Create(Direction.left, Djed.dl), Direction.down},
            {Tuple.Create(Direction.left, Djed.dr), Direction.up},

            {Tuple.Create(Direction.right, Djed.dl), Direction.up},
            {Tuple.Create(Direction.right, Djed.dr), Direction.down},
        };


        public static readonly Dictionary<Tuple<Direction, Pyramid>, Direction> PyramidDirection = new Dictionary<Tuple<Direction, Pyramid>, Direction>
        {
            {Tuple.Create(Direction.up, Pyramid.tl), Direction.kill},
            {Tuple.Create(Direction.up, Pyramid.tr), Direction.kill},
            {Tuple.Create(Direction.up, Pyramid.bl), Direction.right},
            {Tuple.Create(Direction.up, Pyramid.br), Direction.left},

            {Tuple.Create(Direction.down, Pyramid.tl), Direction.right},
            {Tuple.Create(Direction.down, Pyramid.tr), Direction.left},
            {Tuple.Create(Direction.down, Pyramid.bl), Direction.kill},
            {Tuple.Create(Direction.down, Pyramid.br), Direction.kill},

            {Tuple.Create(Direction.left, Pyramid.tl), Direction.kill},
            {Tuple.Create(Direction.left, Pyramid.tr), Direction.down},
            {Tuple.Create(Direction.left, Pyramid.bl), Direction.kill},
            {Tuple.Create(Direction.left, Pyramid.br), Direction.up},

            {Tuple.Create(Direction.right, Pyramid.tl), Direction.down},
            {Tuple.Create(Direction.right, Pyramid.tr), Direction.kill},
            {Tuple.Create(Direction.right, Pyramid.bl), Direction.up},
            {Tuple.Create(Direction.right, Pyramid.br), Direction.kill},
        };



    }

}
