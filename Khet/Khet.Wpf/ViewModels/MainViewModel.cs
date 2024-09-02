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

            squareViewModels[70].activePiece = new PieceViewModel(OrientationDjed.dl);
            squareViewModels[71].activePiece = new PieceViewModel(OrientationDjed.dr);

            squareViewModels[01].activePiece = new PieceViewModel(OrientationDjed.dr);
            squareViewModels[02].activePiece = new PieceViewModel(OrientationDjed.dl);

            squareViewModels[72].activePiece = new PieceViewModel(OrientationDjed.dl);



            //  squareViewModels[0].FireLaser(Direction.down);
            squareViewModels[0].FireLaser(Direction.down);

        }
    }
}
