using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.Events
{
    public class PlayerChangedEvent
    {
        public int newPlayerTurn { get; set; }
        public PlayerChangedEvent(int newPlayerTurn)
        {
            this.newPlayerTurn = newPlayerTurn;
        }
    }
}
