﻿using Khet3.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.MVVM.Models
{
    public static class LaserReflection
    {
        public static readonly Dictionary<(Direction, Orientations), Direction> Djed = new Dictionary<(Direction, Orientations), Direction>
        {
            { (Direction.Up, Orientations.NW), Direction.Left },
            { (Direction.Up, Orientations.NE), Direction.Right },
            { (Direction.Up, Orientations.SE), Direction.Left },
            { (Direction.Up, Orientations.SW), Direction.Right },

            { (Direction.Down, Orientations.NW), Direction.Right },
            { (Direction.Down, Orientations.NE), Direction.Left },
            { (Direction.Down, Orientations.SE), Direction.Right },
            { (Direction.Down, Orientations.SW), Direction.Left },

            { (Direction.Left, Orientations.NW), Direction.Up },
            { (Direction.Left, Orientations.NE), Direction.Down },
            { (Direction.Left, Orientations.SE), Direction.Up },
            { (Direction.Left, Orientations.SW), Direction.Down },

            { (Direction.Right, Orientations.NW), Direction.Down },
            { (Direction.Right, Orientations.NE), Direction.Up },
            { (Direction.Right, Orientations.SE), Direction.Down },
            { (Direction.Right, Orientations.SW), Direction.Up }
        };

        public static readonly Dictionary<(Direction, Orientations), Direction> Pyramid = new Dictionary<(Direction, Orientations), Direction>
        {
            { (Direction.Up, Orientations.NW), Direction.Left },
            { (Direction.Up, Orientations.NE), Direction.Right },
            { (Direction.Up, Orientations.SE), Direction.Stop },
            { (Direction.Up, Orientations.SW), Direction.Stop },

            { (Direction.Down, Orientations.NW), Direction.Stop },
            { (Direction.Down, Orientations.NE), Direction.Stop },
            { (Direction.Down, Orientations.SE), Direction.Right },
            { (Direction.Down, Orientations.SW), Direction.Left },

            { (Direction.Left, Orientations.NW), Direction.Up },
            { (Direction.Left, Orientations.NE), Direction.Stop },
            { (Direction.Left, Orientations.SE), Direction.Stop },
            { (Direction.Left, Orientations.SW), Direction.Down },

            { (Direction.Right, Orientations.NW), Direction.Stop },
            { (Direction.Right, Orientations.NE), Direction.Up },
            { (Direction.Right, Orientations.SE), Direction.Down },
            { (Direction.Right, Orientations.SW), Direction.Stop }
        };
    }
}
