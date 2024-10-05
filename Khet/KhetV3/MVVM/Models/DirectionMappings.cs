using Khet3.Enums;
using KhetV3.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.MVVM.Models
{
    public static class DirectionMappings
    {
        public static readonly Dictionary<Direction, Direction> flip = new Dictionary<Direction, Direction>()
        {
            {Direction.Up, Direction.Down},
            {Direction.Down,Direction.Up },
            {Direction.Left, Direction.Right},
            {Direction.Right,Direction.Left },
        };

        public static readonly Dictionary<Direction, LaserPosition> ToLaserPosition = new Dictionary<Direction, LaserPosition>()
        {

            { Direction.Left, LaserPosition.Left},
            { Direction.Right, LaserPosition.Right},
            { Direction.Up, LaserPosition.Top},
            { Direction.Down, LaserPosition.Bottom},
            { Direction.Stop, LaserPosition.None},

        };



    }
}
