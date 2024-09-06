using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Khet.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private BoardViewModel _boardViewModel;
        public BoardViewModel boardViewModel { get => _boardViewModel; set => SetProperty(ref _boardViewModel, value); }


        public MainViewModel()
        {

            boardViewModel = new BoardViewModel();

        }

    }
}
