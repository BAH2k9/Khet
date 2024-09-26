using Khet2._0.Events;
using Stylet;
using System;

namespace Khet2._0.MVVM.ViewModel
{
    public class GameViewModel : Screen, IHandle<GameBeginEvent>, IHandle<PieceMoveEvent>
    {
        private BoardViewModel _boardViewModel;
        public BoardViewModel boardViewModel { get => _boardViewModel; set => SetAndNotify(ref _boardViewModel, value); }

        private bool _canPlayer1Fire;
        public bool canPlayer1Fire { get => _canPlayer1Fire; set => SetAndNotify(ref _canPlayer1Fire, value); }

        private bool _canPlayer2Fire;
        public bool canPlayer2Fire { get => _canPlayer2Fire; set => SetAndNotify(ref _canPlayer2Fire, value); }

        private EventAggregator _eventAggregator;

        public GameViewModel(BoardViewModel boardViewModel, EventAggregator eventAggregator)
        {
            this.boardViewModel = boardViewModel;
            _eventAggregator = eventAggregator;

            _eventAggregator.Subscribe(this);

            canPlayer1Fire = false;
            canPlayer2Fire = false;
        }

        public void ExecuteFireLaserP1()
        {
            _eventAggregator.Publish(new LaserFireEvent { player = 1 });
            _eventAggregator.Publish(new PlayerTurnEvent(2));

            canPlayer1Fire = false;
        }

        public void ExecuteFireLaserP2()
        {
            _eventAggregator.Publish(new LaserFireEvent { player = 2 });
            _eventAggregator.Publish(new PlayerTurnEvent(1));

            canPlayer2Fire = false;
        }

        public void Handle(GameBeginEvent e)
        {
            _eventAggregator.Publish(new PlayerTurnEvent(1));
        }

        public void Handle(PieceMoveEvent e)
        {
            if (e.playerTurn == 1)
            {
                canPlayer1Fire = true;
            }
            else
            {
                canPlayer2Fire = true;
            }
        }
    }
}