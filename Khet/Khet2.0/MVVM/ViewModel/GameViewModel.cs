using Khet2._0.Events;
using Stylet;
using System;

namespace Khet2._0.MVVM.ViewModel
{
    public class GameViewModel : Screen
    {
        private BoardViewModel _boardViewModel;
        public BoardViewModel boardViewModel { get => _boardViewModel; set => SetAndNotify(ref _boardViewModel, value); }

        private EventAggregator _eventAggregator;

        public GameViewModel(BoardViewModel boardViewModel, EventAggregator eventAggregator)
        {
            this.boardViewModel = boardViewModel;
            _eventAggregator = eventAggregator;
        }

        public void ExecuteFireLaserP1()
        {
            _eventAggregator.Publish(new LaserFireEvent { player = 1 });
        }

        public void ExecuteFireLaserP2()
        {
            _eventAggregator.Publish(new LaserFireEvent { player = 2 });
        }

    }
}