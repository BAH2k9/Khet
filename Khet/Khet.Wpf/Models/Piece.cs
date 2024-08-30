using Khet.Wpf.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Wpf.Models
{
    public class Piece
    {
        public State state {  get; set; }
        public Piece()
        {
            state = State.dl;    
        }
    }
}
