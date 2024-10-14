using Khet3.Enums;
using KhetV3.Interfaces;
using Stylet;

namespace KhetV3.MVVM.ViewModels
{
    public class CapturedPiecesViewModel : Screen, IHandle<PieceCapturedEvent>
    {

        public BindableCollection<IPiece> Pieces { get; set; }
        private int _player;

        public CapturedPiecesViewModel(EventAggregator eventAggregator, int player)
        {
            _player = player;
            eventAggregator.Subscribe(this);
            Pieces = new BindableCollection<IPiece>();

        }

        public void Handle(PieceCapturedEvent e)
        {
            if (e.Piece.player == _player)
            {
                Pieces.Add(e.Piece);
            }

        }
    }
}
