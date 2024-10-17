using Khet3.Enums;
using Khet3.Events;
using KhetV3.Events;
using Stylet;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace KhetV3.MVVM.ViewModels
{
    public class GameEndViewModel : Screen
    {
        EventAggregator _EventAggregator;
        private HomeButtonViewModel _HomeButton;
        public HomeButtonViewModel HomeButton { get => _HomeButton; set => SetAndNotify(ref _HomeButton, value); }

        private PharaohViewModel _WinnersPharaoh;
        public PharaohViewModel WinnersPharaoh { get => _WinnersPharaoh; set => SetAndNotify(ref _WinnersPharaoh, value); }

        private Brush _WinnersColor;
        public Brush WinnersColor { get => _WinnersColor; set => SetAndNotify(ref _WinnersColor, value); }

        private GameViewModel _Creator;


        public GameEndViewModel(EventAggregator eventAggregator, HomeButtonViewModel homeButtonViewModel, GameViewModel gameViewModel)
        {
            _EventAggregator = eventAggregator;
            _Creator = gameViewModel;
            HomeButton = homeButtonViewModel;

        }

        public void Close()
        {
            _Creator.GameEndViewModel = null;
        }

        public void RestartGame()
        {

        }


        public void SetWinner(PharaohViewModel pharaoh)
        {
            var Loser = pharaoh.player;

            if (Loser == 1)
            {
                WinnersPharaoh = new PharaohViewModel(2);
            }
            else if (Loser == 2)
            {
                WinnersPharaoh = new PharaohViewModel(1);
            }

            WinnersColor = WinnersPharaoh.GetColor();


        }

        internal void GiveReference(GameViewModel gameViewModel)
        {
            _Creator = gameViewModel;
        }
    }
}
