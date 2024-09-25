using Khet2._0.CustomTypes;
using Khet2._0.MVVM.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet2._0.Events
{
    public class SquareClickEvent
    {
        public bool hasPiece = false;

        public SquareViewModel square { get; set; }

        public SquareClickEvent(SquareViewModel square)
        {
            this.square = square;

            if (square.ActivePiece != null)
            {
                hasPiece = true;
            }
        }
    }
}
