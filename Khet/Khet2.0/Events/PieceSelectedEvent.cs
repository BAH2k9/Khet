using Khet2._0.CustomTypes;

namespace Khet2._0.Events
{
    public class PieceSelectedEvent
    {
        public Idx idx;

        public PieceSelectedEvent(Idx idx)
        {
            this.idx = idx;
        }
    }
}