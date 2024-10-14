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
                playerColor = Brushes.Silver;
            }
            else
            {
                playerColor = Brushes.Red;
            }
        }
    }
}
