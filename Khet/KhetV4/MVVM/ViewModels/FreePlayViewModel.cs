using Stylet;

namespace KhetV4.MVVM.ViewModels
{
    public class FreePlayViewModel : Screen
    {
        private BoardViewModel _boardViewModel;
        public BoardViewModel BoardViewModel { get => _boardViewModel; set => SetAndNotify(ref _boardViewModel, value); }
        public FreePlayViewModel(BoardViewModel boardViewModel)
        {
            BoardViewModel = boardViewModel;
        }
    }
}