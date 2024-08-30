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


            squareViewModels[30].activePiece = new PieceViewModel() { state = State.dl };
            squareViewModels[33].activePiece = new PieceViewModel() { state = State.dl };


            squareViewModels[49].activePiece = new PieceViewModel() { state = State.dl };
            squareViewModels[45].activePiece = new PieceViewModel() { state = State.dl };
            

            squareViewModels[0].FireLaser(Direction.down);
            squareViewModels[squareViewModels.Count-1].FireLaser(Direction.up);

        }
    }
}
