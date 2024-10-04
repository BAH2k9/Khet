using Khet3.Enums;
using KhetV3.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.MVVM.Models
{
    public record LaserResponse
    {
        public (LaserPosition, LaserPosition) LaserPositions { get; set; }
        public Direction direction { get; set; }
        public LaserResponse((LaserPosition, LaserPosition) laserPos, Direction direction)
        {
            this.LaserPositions = laserPos;
            this.direction = direction;
        }

    }
}
