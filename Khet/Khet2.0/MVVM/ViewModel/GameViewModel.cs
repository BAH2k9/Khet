using Khet2._0.Enums;
using Khet2._0.Events;
using Khet2._0.MVVM.Models;
using Stylet;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Khet2._0.MVVM.ViewModel
{
    public class GameViewModel : Screen, IHandle<PieceMoveEvent>
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
            _eventAggregator.Subscribe(this);

            BeginGame();

        }

        public void BeginGame()
        {
            _eventAggregator.Publish(new PlayerChangeEvent(1));

        }

        public void ExecuteFireLaserP1()
        {
            _eventAggregator.Publish(new LaserFireEvent { player = 1 });
            _eventAggregator.Publish(new PlayerChangeEvent(2));

            DisablePlayerLaser(1);
        }

        public void ExecuteFireLaserP2()
        {
            _eventAggregator.Publish(new LaserFireEvent { player = 2 });
            _eventAggregator.Publish(new PlayerChangeEvent(1));

            DisablePlayerLaser(2);
        }

        private void DisablePlayerLaser(int player)
        {
            switch (player)
            {
                case 1:
                    IsEnabledP1 = false;
                    break;
                case 2:
                    IsEnabledP2 = false;
                    break;
                default: break;
            }
        }

        private void EnablePlayerLaser(int player)
        {
            switch (player)
            {
                case 1:
                    IsEnabledP1 = true;
                    break;
                case 2:
                    IsEnabledP2 = true;
                    break;
                default: break;
            }
        }

        public void Handle(PieceMoveEvent e)
        {
            EnablePlayerLaser(e.player);

        }

        public void ExecuteKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                Trace.WriteLine("Left key pressed");
                var rotationDirection = RotationDirection.CCW;
                _eventAggregator.Publish(new RotateEvent(rotationDirection));
                return;

            }
            if (e.Key == Key.Right)
            {
                Trace.WriteLine("Right key pressed");
                var rotationDirection = RotationDirection.CW;
                _eventAggregator.Publish(new RotateEvent(rotationDirection));
                return;
            }

            e.Handled = true;

        }
    }
}