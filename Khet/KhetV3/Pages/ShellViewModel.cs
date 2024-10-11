using Khet3.Enums;
using Khet3.Events;
using KhetV3.MVVM.ViewModels;
using Stylet;

namespace KhetV3.Pages
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive, IHandle<NavigateEvent>
    {
        private EventAggregator _eventAggregator;
        private HomeViewModel _homeViewModel;
        private GameViewModel _gameViewModel;
        public ShellViewModel(EventAggregator eventAggregator,
                                HomeViewModel homeViewModel,
                                GameViewModel gameViewModel)
        {
            _eventAggregator = eventAggregator;
            _homeViewModel = homeViewModel;
            _gameViewModel = gameViewModel;

            _eventAggregator.Subscribe(this);

            ActivateItem(_homeViewModel);

        }

        public void Handle(NavigateEvent e)
        {
            switch (e.page)
            {
                case AppPages.Home:
                    ActivateItem(_homeViewModel);
                    break;
                case AppPages.FreePlay:
                    ActivateItem(_gameViewModel);
                    break;
                case AppPages.LocalGame:
                    _gameViewModel.SetPlayerRules();
                    ActivateItem(_gameViewModel);
                    break;

            }
        }


    }
}
