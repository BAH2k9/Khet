using Khet2._0.Events;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet2._0.MVVM.ViewModel
{
    public class CapturedPieceViewModel : Screen, IHandle<PieceCapturedEvent>
    {
        //private EventAggregator _eventAggregator;

        private PyramidViewModel _pyramidViewModel;
        public PyramidViewModel pyramidViewModel { get => _pyramidViewModel; set => SetAndNotify(ref _pyramidViewModel, value); }

        private ObeliskViewModel _obeliskViewModel;
        public ObeliskViewModel obeliskViewModel { get => _obeliskViewModel; set => SetAndNotify(ref _obeliskViewModel, value); }

        private int _capturedPyramids = 0;
        public int capturedPyramids { get => _capturedPyramids; set => SetAndNotify(ref _capturedPyramids, value); }

        private int _capturedObelisks = 0;
        public int capturedObelisks { get => _capturedObelisks; set => SetAndNotify(ref _capturedObelisks, value); }

        private int player;

        public CapturedPieceViewModel(EventAggregator eventAggregator, int player)
        {
            this.player = player;
            eventAggregator.Subscribe(this);

            pyramidViewModel = new PyramidViewModel(Enums.Orientations.NE, player);
            obeliskViewModel = new ObeliskViewModel(player);
        }

        public void Handle(PieceCapturedEvent e)
        {
            if (e.piece.player == player)
            {
                switch (e.piece)
                {
                    case PyramidViewModel:
                        capturedPyramids++;
                        break;
                    case ObeliskViewModel:
                        capturedObelisks++;
                        break;
                }
            }

        }
    }
}
