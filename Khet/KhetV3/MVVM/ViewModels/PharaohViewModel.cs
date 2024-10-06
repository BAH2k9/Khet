using KhetV3.AbstractClasses;
using KhetV3.Interfaces;
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
        public int player { get; set; }
        public PharaohViewModel(int player)
        {
            this.player = player;

            SetColor(player);
        }

    }
}
