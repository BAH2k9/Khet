using Khet3.Enums;
using KhetV3.AbstractClasses;
using KhetV3.Enums;
using KhetV3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.Services
{
    public class HistoryService
    {
        public List<((int, int) startPosition, (int, int) endPosition)> shiftHistory = [];
        public List<(IRotatable, Orientations startOrientation, Orientations endOrientation)> rotateHistory = [];
        public MoveType MostRecentMoveType { get; set; }


        public void AddShift((int, int) start, (int, int) end)
        {
            MostRecentMoveType = MoveType.Shift;
            shiftHistory.Add((start, end));
        }

        public void AddRotate(IRotatable rotatablePiece, Orientations startOrientation, Orientations endOrientation)
        {
            MostRecentMoveType = MoveType.Rotate;
            rotateHistory.Add((rotatablePiece, startOrientation, endOrientation));
        }

        public ((int, int), (int, int)) GetLastShift()
        {
            return shiftHistory.Last();
        }

        public (IRotatable, Orientations, Orientations) GetLastRotation()
        {
            return rotateHistory.Last();
        }
    }
}
