using Khet3.Enums;
using Khet3.Events;
using KhetV3.MVVM.ViewModels;
using KhetV3.Services;
using Stylet;
using StyletIoC;
using System.Threading.Tasks;
using System.Windows;

namespace KhetV3.Pages
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive, IHandle<NavigateEvent>
    {
        private IContainer _container;
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

        public ShellViewModel(IContainer container)
        {
            _container = container;
            Height = 600;
            Width = 900;


            _eventAggregator = _container.Get<EventAggregator>(); ;

            _eventAggregator.Subscribe(this);

            windowState = WindowState.Normal;

            ActivateItem(_container.Get<HomeViewModel>());

        }

        public async void Handle(NavigateEvent e)
        {
            switch (e.page)
            {
                case AppPages.Home:
                    ActivateItem(_container.Get<HomeViewModel>());
                    break;
                case AppPages.FreePlay:
                    _gameViewModel = _container.Get<GameViewModel>();
                    _eventAggregator.Publish(new NewGameEvent());

                    ActivateItem(_gameViewModel);
                    await Task.Delay(500);
                    windowState = WindowState.Maximized;
                    break;
                case AppPages.LocalGame:

                    _gameViewModel = _container.Get<GameViewModel>();
                    _eventAggregator.Publish(new NewGameEvent());
                    _gameViewModel.SetPlayerRules();

                    ActivateItem(_gameViewModel);
                    await Task.Delay(500);
                    windowState = WindowState.Maximized;
                    break;

            }
        }
    }
}

