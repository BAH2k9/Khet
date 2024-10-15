using KhetV3.AbstractClasses;
using KhetV3.Interfaces;
using KhetV3.Services;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KhetV3.MVVM.ViewModels
{
    public class PharaohViewModel : Piece
    {
        private ClickService _clickService;
        public PharaohViewModel(ClickService clickService, int player)
        {
            this.player = player;
            _clickService = clickService;

            SetColor(player);
        }

        public PharaohViewModel(int player)
        {
            this.player = player;
            SetColor(player);
        }

        public void ExecuteMouseDown()
        {
            _clickService.Click(this);
        }

    }
}
