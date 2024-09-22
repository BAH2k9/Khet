using Khet.Wpf.AbstractClasses;
using Khet.Wpf.Enums;
using Khet.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Khet.Wpf.Models
{
    public class GameModel
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public GameModel()
        {
            Player1 = new Player("Player 1", 1, Brushes.DarkGray);
            Player2 = new Player("Player 2", 2, Brushes.Red);

            // Assign pieces to each player
            InitialisePieces(Player1);
            InitialisePieces(Player2);
        }

        private void InitialisePieces(Player player)
        {
            var pieceList = new List<Piece>
            {
                //new PyramidViewModel(Pyramid.BL, player),
                //new PyramidViewModel(Pyramid.TL, player),
                //new PyramidViewModel(Pyramid.TR, player),
                //new ObeliskViewModel(player),
                //new DjedViewModel(Djed.DL, player),
                //new PharaohViewModel(player),
                //new DjedViewModel(Djed.DR, player),
                //new ObeliskViewModel(player),
                //new PyramidViewModel(Pyramid.TL, player),
                //new PyramidViewModel(Pyramid.TL, player),
                //new PyramidViewModel(Pyramid.TL, player),
                //new PyramidViewModel(Pyramid.BL, player)
            };

            //player.Pieces = pieceList;

        }
    }

}
