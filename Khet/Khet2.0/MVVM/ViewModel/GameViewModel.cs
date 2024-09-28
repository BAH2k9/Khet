using Khet2._0.Events;
using Khet2._0.MVVM.Models;
using Stylet;
using System;

namespace Khet2._0.MVVM.ViewModel
{
    public class GameViewModel : Screen
    {
        private BoardViewModel _boardViewModel;
        public BoardViewModel boardViewModel { get => _boardViewModel; set => SetAndNotify(ref _boardViewModel, value); }

        private EventAggregator _eventAggregator;

        private bool _IsEnabledP1;
        public bool IsEnabledP1 { get => _IsEnabledP1; set => SetAndNotify(ref _IsEnabledP1, value); }

        private bool _IsEnabledP2;
        public bool IsEnabledP2 { get => _IsEnabledP2; set => SetAndNotify(ref _IsEnabledP2, value); }

        public GameViewModel(BoardViewModel boardViewModel, EventAggregator eventAggregator)
        {
            this.boardViewModel = boardViewModel;
            _eventAggregator = eventAggregator;

            BeginGame();
        }

        public void BeginGame()
        {
            _eventAggregator.Publish(new PlayerChangeEvent(1));
            IsEnabledP1 = true;
            IsEnabledP2 = false;
        }

        public void ExecuteFireLaserP1()
        {
            _eventAggregator.Publish(new LaserFireEvent { player = 1 });
            _eventAggregator.Publish(new PlayerChangeEvent(1));

            IsEnabledP1 = false;
            IsEnabledP2 = true;
        }

        public void ExecuteFireLaserP2()
        {
            _eventAggregator.Publish(new LaserFireEvent { player = 2 });
            _eventAggregator.Publish(new PlayerChangeEvent(2));

            IsEnabledP1 = true;
            IsEnabledP2 = false;
        }

    }
}