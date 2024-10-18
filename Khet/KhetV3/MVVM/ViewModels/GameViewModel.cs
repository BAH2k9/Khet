using Khet3.Enums;
using Khet3.Events;
using KhetV3.Events;
using KhetV3.MVVM.Models;
using KhetV3.Services;
using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.MVVM.ViewModels
{
    public class GameViewModel : Screen, IHandle<PlayerChangedEvent>, IHandle<PieceMovedEvent>, IHandle<UndoMoveEvent>, IHandle<GameEndEvent>
    {
        public BoardViewModel BoardViewModel { get; set; }

        private BoardUpdateService _boardUpdateService;
        private FireLaserService _fireLaserService;
        private EventAggregator _eventAggregator;

        private readonly int rows = 8;
        private readonly int cols = 10;

        private float _Laser1Opacity;
        public float Laser1Opacity { get => _Laser1Opacity; set => SetAndNotify(ref _Laser1Opacity, value); }

        private bool _Laser1Enabled;
        public bool Laser1Enabled { get => _Laser1Enabled; set => SetAndNotify(ref _Laser1Enabled, value); }



        private float _Laser2Opacity;
        public float Laser2Opacity { get => _Laser2Opacity; set => SetAndNotify(ref _Laser2Opacity, value); }

        private bool _Laser2Enabled;
        public bool Laser2Enabled { get => _Laser2Enabled; set => SetAndNotify(ref _Laser2Enabled, value); }



        private float _BackButtonOpacity;
        public float BackButtonOpacity { get => _BackButtonOpacity; set => SetAndNotify(ref _BackButtonOpacity, value); }

        private bool _BackButtonEnabled;
        public bool BackButtonEnabled { get => _BackButtonEnabled; set => SetAndNotify(ref _BackButtonEnabled, value); }



        private float _ForwardButtonOpacity;
        public float ForwardButtonOpacity { get => _ForwardButtonOpacity; set => SetAndNotify(ref _ForwardButtonOpacity, value); }

        private bool _ForwardButtonEnabled;
        public bool ForwardButtonEnabled { get => _ForwardButtonEnabled; set => SetAndNotify(ref _ForwardButtonEnabled, value); }

        private HomeButtonViewModel _HomeButtonViewModel;
        public HomeButtonViewModel HomeButtonViewModel { get => _HomeButtonViewModel; set => SetAndNotify(ref _HomeButtonViewModel, value); }

        private CapturedPiecesViewModel _capturedPieces1;
        public CapturedPiecesViewModel capturedPieces1 { get => _capturedPieces1; set => SetAndNotify(ref _capturedPieces1, value); }

        private CapturedPiecesViewModel _capturedPieces2;
        public CapturedPiecesViewModel capturedPieces2 { get => _capturedPieces2; set => SetAndNotify(ref _capturedPieces2, value); }


        private GameEndViewModel _GameEndViewModel;
        public GameEndViewModel GameEndViewModel { get => _GameEndViewModel; set => SetAndNotify(ref _GameEndViewModel, value); }



        private WindowManager _windowManager;

        public GameViewModel(EventAggregator eventAggregator,
                             BoardViewModel boardViewModel,
                             HomeButtonViewModel homeButtonViewModel,
                             BoardUpdateService boardUpdateService,
                             FireLaserService fireLaserService,
                             WindowManager windowManager)
        {

            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            this.BoardViewModel = boardViewModel;
            this.BoardViewModel.SetDimensions(rows, cols);
            this.BoardViewModel.Initialise();

            this.HomeButtonViewModel = homeButtonViewModel;
            _boardUpdateService = boardUpdateService;
            _fireLaserService = fireLaserService;
            _fireLaserService.SetBoardDimensions(rows, cols);


            Laser1Opacity = 0.5f;
            Laser2Opacity = 0.5f;
            Laser1Enabled = true;
            Laser2Enabled = true;

            BackButtonOpacity = 0.0f;
            ForwardButtonOpacity = 0.0f;
            BackButtonEnabled = false;
            ForwardButtonEnabled = false;

            capturedPieces1 = new CapturedPiecesViewModel(eventAggregator, 2);
            capturedPieces2 = new CapturedPiecesViewModel(eventAggregator, 1);



        }

        public void SetPlayerRules()
        {
            Laser1Opacity = 0.5f;
            Laser2Opacity = 0.0f;
            Laser1Enabled = false;
            Laser2Enabled = false;

            this.BoardViewModel.SetPlayerRules();

        }


        public void Handle(PieceMovedEvent e)
        {
            if (e.player == 1)
            {
                Laser1Opacity = 0.5f;
                Laser1Enabled = true;
            }
            else if (e.player == 2)
            {
                Laser2Opacity = 0.5f;
                Laser2Enabled = true;

            }

            BackButtonEnabled = true;
            BackButtonOpacity = 0.5f;
        }

        public void Handle(PlayerChangedEvent e)
        {
            if (e.newPlayerTurn == 1)
            {
                Laser1Opacity = 0.5f;
                Laser2Opacity = 0.0f;

                Laser1Enabled = false;
                Laser2Enabled = false;

            }
            else if (e.newPlayerTurn == 2)
            {
                Laser1Opacity = 0.0f;
                Laser2Opacity = 0.5f;

                Laser1Enabled = false;
                Laser2Enabled = false;

            }

            BackButtonEnabled = false;
            BackButtonOpacity = 0.0f;

        }

        public void Handle(UndoMoveEvent message)
        {
            if (Laser1Enabled)
            {
                Laser1Enabled = false;
            }

            if (Laser2Enabled)
            {
                Laser2Enabled = false;
            }
        }

        public void Handle(GameEndEvent e)
        {
            var HomeButton = new HomeButtonViewModel(_eventAggregator);
            GameEndViewModel = new GameEndViewModel(_eventAggregator, HomeButton, this);
            GameEndViewModel.SetWinner(e.PharaohViewModel);


        }

        public async void ExecuteFireLaserP1()
        {
            Trace.WriteLine("Player 1 fire laser clicked!");

            BackButtonEnabled = false;

            await _fireLaserService.CalculateLaserPath((7, 9), Direction.Up);

        }

        public async void ExecuteFireLaserP2()
        {
            Trace.WriteLine("Player 2 fire laser clicked!");

            BackButtonEnabled = false;

            await _fireLaserService.CalculateLaserPath((0, 0), Direction.Down);
        }


        public void OnBackButton()
        {
            _boardUpdateService.UndoMove();

            BackButtonEnabled = false;
            BackButtonOpacity = 0.0f;

            _eventAggregator.Publish(new UndoMoveEvent());
        }


        public void OnMouseEnterLaser1()
        {
            HighlightLaserButton(1);
        }

        public void OnMouseLeaveLaser1()
        {
            DullLaserButton(1);
        }

        public void OnMouseEnterLaser2()
        {
            HighlightLaserButton(2);
        }

        public void OnMouseLeaveLaser2()
        {
            DullLaserButton(2);
        }

        public void OnMouseEnterBackButton()
        {
            if (BackButtonEnabled)
            {
                BackButtonOpacity = 1.0f;
            }

        }

        public void OnMouseLeaveBackButton()
        {
            if (BackButtonEnabled)
            {
                BackButtonOpacity = 0.5f;
            }

        }

        public void OnMouseEnterForwardButton()
        {
            if (ForwardButtonEnabled)
            {
                ForwardButtonOpacity = 1.0f;
            }

        }

        public void OnMouseLeaveForwardButton()
        {
            if (ForwardButtonEnabled)
            {
                ForwardButtonOpacity = 0.5f;
            }

        }

        public void HighlightLaserButton(int player)
        {
            if (player == 1)
            {
                if (Laser1Enabled)
                {
                    Laser1Opacity = 1.0f;
                }

            }
            else if (player == 2)
            {
                if (Laser2Enabled)
                {
                    Laser2Opacity = 1.0f;
                }
            }
        }

        public void DullLaserButton(int player)
        {
            if (player == 1)
            {
                if (Laser1Enabled)
                {
                    Laser1Opacity = 0.5f;
                }

            }
            else if (player == 2)
            {
                if (Laser2Enabled)
                {
                    Laser2Opacity = 0.5f;
                }

            }
        }


    }
}
