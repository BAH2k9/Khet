using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Models;
using System.Collections.ObjectModel;

namespace Khet.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<SquareViewModel> squareViewModels {get; set;}

        public MainViewModel()
        {
            
            var sf = new SquareFactory();

            squareViewModels = sf.GetObservableCollection();


           // squareViewModels[50].activePiece = new PieceViewModel() { orientation = OrientationDjed.dl };
           //squareViewModels[55].activePiece = new PieceViewModel() { orientation = OrientationDjed.dl };

            squareViewModels[50].activePiece = new PieceViewModel(OrientationDjed.dl);
            squareViewModels[55].activePiece = new PieceViewModel(OrientationDjed.dr);



          //  squareViewModels[0].FireLaser(Direction.down);
            squareViewModels[0].FireLaser(Direction.down);

        }
    }
}
