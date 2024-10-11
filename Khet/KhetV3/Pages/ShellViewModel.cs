using Khet3.Enums;
using Khet3.Events;
using KhetV3.MVVM.ViewModels;
using Stylet;
using System.Threading.Tasks;
using System.Windows;

namespace KhetV3.Pages
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive, IHandle<NavigateEvent>
    {
        private EventAggregator _eventAggregator;
        private HomeViewModel _homeViewModel;
        private GameViewModel _gameViewModel;

        private WindowState _windowState;

        private double screenWidth = SystemParameters.PrimaryScreenWidth;
        private double screenHeight = SystemParameters.PrimaryScreenHeight;

        private double _Height;
        public double Height { get => _Height; set => SetAndNotify(ref _Height, value); }

        private double _Width;
        public double Width { get => _Width; set => SetAndNotify(ref _Width, value); }

        public WindowState windowState { get => _windowState; set => SetAndNotify(ref _windowState, value); }

        public ShellViewModel(EventAggregator eventAggregator,
                                HomeViewModel homeViewModel,
                                GameViewModel gameViewModel)
        {
            Height = 800;
            Width = 1250;


            _eventAggregator = eventAggregator;
            _homeViewModel = homeViewModel;
            _gameViewModel = gameViewModel;

            _eventAggregator.Subscribe(this);

            windowState = WindowState.Normal;

            ActivateItem(_homeViewModel);

        }

        public async void Handle(NavigateEvent e)
        {
            switch (e.page)
            {
                case AppPages.Home:
                    ActivateItem(_homeViewModel);
                    break;
                case AppPages.FreePlay:

                    ActivateItem(_gameViewModel);

                    await Task.Delay(500);
                    windowState = WindowState.Maximized;
                    break;
                case AppPages.LocalGame:

                    _gameViewModel.SetPlayerRules();
                    ActivateItem(_gameViewModel);
                    await Task.Delay(500);
                    windowState = WindowState.Maximized;
                    break;

            }
        }
    }
}

