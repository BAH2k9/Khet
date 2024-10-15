using KhetV3.MVVM.ViewModels;
using System;

namespace KhetV3.Events
{
    public class GameEndEvent
    {
        public int player { get; set; }

        public PharaohViewModel PharaohViewModel { get; set; }

        public GameEndEvent(PharaohViewModel pharaohViewModel)
        {
            this.PharaohViewModel = pharaohViewModel;
            this.player = pharaohViewModel.player;
        }
    }
}