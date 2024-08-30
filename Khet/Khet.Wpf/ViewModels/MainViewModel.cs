using Khet.Wpf.Core;

namespace Khet.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private SquareViewModel _squareViewModel1;
        public SquareViewModel squareViewModel1 { get => _squareViewModel1; set => SetProperty(ref _squareViewModel1, value); }

        private SquareViewModel _squareViewModel2;
        public SquareViewModel squareViewModel2 { get => _squareViewModel2; set => SetProperty(ref _squareViewModel2, value); }

        private SquareViewModel _squareViewModel3;
        public SquareViewModel squareViewModel3 { get => _squareViewModel3; set => SetProperty(ref _squareViewModel3, value); }

        private SquareViewModel _squareViewModel4;
        public SquareViewModel squareViewModel4 { get => _squareViewModel4; set => SetProperty(ref _squareViewModel4, value); }

        public MainViewModel()
        {
            squareViewModel1 = new SquareViewModel();
            squareViewModel2 = new SquareViewModel();
            squareViewModel3 = new SquareViewModel();
            squareViewModel4 = new SquareViewModel();
        }
    }
}
