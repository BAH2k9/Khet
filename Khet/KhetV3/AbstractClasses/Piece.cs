using KhetV3.Interfaces;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KhetV3.AbstractClasses
{
    public abstract class Piece : Screen, IPiece
    {
        private Brush Color1 = Brushes.Silver;
        private Brush Color2 = Brushes.Red;

        public int player { get; set; }
        public (int row, int col) position { get; set; }

        private Brush _playerColor;
        public Brush playerColor { get => _playerColor; set => SetAndNotify(ref _playerColor, value); }
        public void SetPosition((int, int) position)
        {
            this.position = position;
        }



        public virtual void SetColor(int player)
        {
            if (player == 1)
            {
                playerColor = Color1;
            }
            else
            {
                playerColor = Color2;
            }
        }

        public virtual Brush GetColor()
        {
            return playerColor;
        }
    }
}
