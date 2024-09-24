using Khet2._0.Enums;
using Khet2._0.Events;
using Khet2._0.MVVM.ViewModel;
using Stylet;

namespace Khet2._0.Pages
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
                case AppPages.Game:
                    ActivateItem(_gameViewModel);
                    break;

            }
        }


    }
}
