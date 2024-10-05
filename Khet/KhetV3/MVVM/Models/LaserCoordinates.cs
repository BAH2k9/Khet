using Stylet;

namespace KhetV3.MVVM.Models
{
    public class LaserCoordinates : Screen
    {
        private double _x1;
        public double x1 { get => _x1; set => SetAndNotify(ref _x1, value); }

        private double _y1;
        public double y1 { get => _y1; set => SetAndNotify(ref _y1, value); }

        private double _x2;
        public double x2 { get => _x2; set => SetAndNotify(ref _x2, value); }

        private double _y2;
        public double y2 { get => _y2; set => SetAndNotify(ref _y2, value); }

    }

}
