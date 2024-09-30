using Khet2._0.Enums;

namespace Khet2._0.Events
{
    public class RotateEvent
    {
        public RotationDirection direction;

        public RotateEvent(RotationDirection rotationDirection)
        {
            this.direction = rotationDirection;
        }
    }
}