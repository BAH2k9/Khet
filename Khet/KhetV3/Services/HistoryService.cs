using KhetV3.AbstractClasses;
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
        public Dictionary<int, ((int, int) startPosition, (int, int) endPosition)> history = [];


        private int MoveNumber = 1;

        public void AddShift((int, int) start, (int, int) end)
        {
            MoveNumber++;

            history[MoveNumber] = (start, end);
        }

        public ((int, int), (int, int)) GetLastMove()
        {
            return history[MoveNumber];
        }
    }
}
