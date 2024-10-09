using Khet3.Enums;
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
    public class GameViewModel : Screen, IHandle<PlayerChangedEvent>, IHandle<PieceMovedEvent>
    {
        public BoardViewModel BoardViewModel { get; set; }
        private FireLaserService _fireLaserService { get; set; }

        private readonly int rows = 8;
        private readonly int cols = 10;

        private float _opacity1;
        public float opacity1 { get => _opacity1; set => SetAndNotify(ref _opacity1, value); }

        private float _opacity2;
        public float opacity2 { get => _opacity2; set => SetAndNotify(ref _opacity2, value); }

        private bool _IsEnabled1;
        public bool IsEnabled1 { get => _IsEnabled1; set => SetAndNotify(ref _IsEnabled1, value); }

        private bool _IsEnabled2;
        public bool IsEnabled2 { get => _IsEnabled2; set => SetAndNotify(ref _IsEnabled2, value); }
        public GameViewModel(EventAggregator eventAggregator, BoardViewModel boardViewModel, FireLaserService fireLaserService)
        {
            eventAggregator.Subscribe(this);

            this.BoardViewModel = boardViewModel;
            this.BoardViewModel.SetDimensions(rows, cols);
            this.BoardViewModel.Initialise();

            _fireLaserService = fireLaserService;
            _fireLaserService.SetBoardDimensions(rows, cols);


            opacity1 = 0.5f;
            opacity2 = 0.5f;
            IsEnabled1 = true;
            IsEnabled2 = true;
        }

        public void SetPlayerRules()
        {
            opacity1 = 0.5f;
            opacity2 = 0.0f;
            IsEnabled1 = false;
            IsEnabled2 = false;

            this.BoardViewModel.SetPlayerRules();

        }

        public async void ExecuteFireLaserP1()
        {
            Trace.WriteLine("Player 1 fire laser clicked!");

            await _fireLaserService.CalculateLaserPath((7, 9), Direction.Up);

        }

        public async void ExecuteFireLaserP2()
        {
            Trace.WriteLine("Player 2 fire laser clicked!");

            await _fireLaserService.CalculateLaserPath((0, 0), Direction.Down);
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

        public void HighlightLaserButton(int player)
        {
            if (player == 1)
            {
                if (IsEnabled1)
                {
                    opacity1 = 1.0f;
                }

            }
            else if (player == 2)
            {
                if (IsEnabled2)
                {
                    opacity2 = 1.0f;
                }
            }
        }

        public void DullLaserButton(int player)
        {
            if (player == 1)
            {
                if (IsEnabled1)
                {
                    opacity1 = 0.5f;
                }

            }
            else if (player == 2)
            {
                if (IsEnabled2)
                {
                    opacity2 = 0.5f;
                }

            }
        }


        public void Handle(PlayerChangedEvent e)
        {
            if (e.newPlayerTurn == 1)
            {
                opacity1 = 0.5f;
                opacity2 = 0.0f;

                IsEnabled1 = false;
                IsEnabled2 = false;

            }
            else if (e.newPlayerTurn == 2)
            {
                opacity1 = 0.0f;
                opacity2 = 0.5f;

                IsEnabled1 = false;
                IsEnabled2 = false;

            }

        }

        public void Handle(PieceMovedEvent e)
        {
            if (e.player == 1)
            {
                IsEnabled1 = true;
            }
            else if (e.player == 2)
            {
                IsEnabled2 = true;

            }
        }
    }
}
