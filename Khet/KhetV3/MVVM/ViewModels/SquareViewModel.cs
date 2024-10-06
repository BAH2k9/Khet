using KhetV3.Interfaces;
using KhetV3.Services;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace KhetV3.MVVM.ViewModels
{
    public class SquareViewModel : Screen
    {
        public IPiece ActivePiece { get; set; }
        private LaserViewModel _ActiveLaser;
        public LaserViewModel ActiveLaser { get => _ActiveLaser; set => SetAndNotify(ref _ActiveLaser, value); }

        private Brush _highlight = Brushes.Transparent;
        public Brush highlight { get => _highlight; set => SetAndNotify(ref _highlight, value); }

        private ClickService _clickService;
        public SquareViewModel(ClickService clickService)
        {
            _clickService = clickService;


        }


        public void Select(bool select)
        {
            if (select)
            {
                highlight = Brushes.Blue;
            }
            else
            {
                highlight = Brushes.Transparent;
            }

        }

        public void ExecuteMouseDown()
        {
            if (this.ActivePiece == null)
            {
                _clickService.Click(this);
            }
        }


    }
}
