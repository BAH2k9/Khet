using Khet.Wpf.Core;
using Khet.Wpf.Models;
using System.Collections.ObjectModel;

namespace Khet.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //private SquareViewModel _squareViewModel1;
        //public SquareViewModel squareViewModel1 { get => _squareViewModel1; set => SetProperty(ref _squareViewModel1, value); }

        //private SquareViewModel _squareViewModel2;
        //public SquareViewModel squareViewModel2 { get => _squareViewModel2; set => SetProperty(ref _squareViewModel2, value); }

        //private SquareViewModel _squareViewModel3;
        //public SquareViewModel squareViewModel3 { get => _squareViewModel3; set => SetProperty(ref _squareViewModel3, value); }

        //private SquareViewModel _squareViewModel4;
        //public SquareViewModel squareViewModel4 { get => _squareViewModel4; set => SetProperty(ref _squareViewModel4, value); }

        public ObservableCollection<SquareViewModel> squareViewModels {get; set;}

        public MainViewModel()
        {
            
            var sf = new SquareFactory();

            squareViewModels = sf.GetObservableCollection();


            //squareViewModel1 = sf.myList[7][9];
            //squareViewModel2 = sf.myList[6][9];
            //squareViewModel3 = sf.myList[5][9];
            //squareViewModel4 = sf.myList[4][9];
        }
    }
}
