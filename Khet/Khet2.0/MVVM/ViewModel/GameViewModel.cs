using Khet2._0.Enums;
using Khet2._0.Events;
using Khet2._0.MVVM.Models;
using Stylet;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Khet2._0.MVVM.ViewModel
{
    public class GameViewModel : Screen, IHandle<PieceMovedEvent>, IHandle<PieceRotatedEvent>, IHandle<PlayerChangeEvent>
    {
        private BoardViewModel _boardViewModel;
        public BoardViewModel boardViewModel { get => _boardViewModel; set => SetAndNotify(ref _boardViewModel, value); }

        private CapturedPieceViewModel _capturedPieceViewModel1;
        public CapturedPieceViewModel capturedPieceViewModel1 { get => _capturedPieceViewModel1; set => SetAndNotify(ref _capturedPieceViewModel1, value); }

        private CapturedPieceViewModel _capturedPieceViewModel2;
        public CapturedPieceViewModel capturedPieceViewModel2 { get => _capturedPieceViewModel2; set => SetAndNotify(ref _capturedPieceViewModel2, value); }

        private EventAggregator _eventAggregator;

        private bool _IsLaserP1Enabled;
        public bool IsLaserP1Enabled { get => _IsLaserP1Enabled; set => SetAndNotify(ref _IsLaserP1Enabled, value); }

        private bool _IsLaserP2Enabled;
        public bool IsLaserP2Enabled { get => _IsLaserP2Enabled; set => SetAndNotify(ref _IsLaserP2Enabled, value); }

        private bool _IsBackButtonEnabled;
        public bool IsBackButtonEnabled { get => _IsBackButtonEnabled; set => SetAndNotify(ref _IsBackButtonEnabled, value); }

        public GameViewModel(BoardViewModel boardViewModel, EventAggregator eventAggregator)
        {
            this.boardViewModel = boardViewModel;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            capturedPieceViewModel1 = new CapturedPieceViewModel(eventAggregator, 1);
            capturedPieceViewModel2 = new CapturedPieceViewModel(eventAggregator, 2);

            DisablePlayerLaser(1);
            DisablePlayerLaser(2);
            DisableBackButton();
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

        public void ExecuteBackButtonClicked()
        {
            _eventAggregator.Publish(new BackButtonClickEvent());
            DisablePlayerLaser(1);
            DisablePlayerLaser(2);
        }

        private void DisablePlayerLaser(int player)
        {
            switch (player)
            {
                case 1:
                    IsLaserP1Enabled = false;
                    break;
                case 2:
                    IsLaserP2Enabled = false;
                    break;
                default: break;
            }
        }

        private void EnablePlayerLaser(int player)
        {
            switch (player)
            {
                case 1:
                    IsLaserP1Enabled = true;
                    break;
                case 2:
                    IsLaserP2Enabled = true;
                    break;
                default: break;
            }
        }

        private void DisableBackButton()
        {
            IsBackButtonEnabled = false;
        }

        private void EnableBackButton()
        {
            IsBackButtonEnabled = true;
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

        public void Handle(PieceMovedEvent e)
        {
            EnablePlayerLaser(e.player);
            EnableBackButton();

        }

        public void Handle(PieceRotatedEvent e)
        {
            EnableBackButton();
        }

        public void Handle(PlayerChangeEvent message)
        {
            DisableBackButton();
        }
    }
}