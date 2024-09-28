using Khet2._0.CustomTypes;
using Khet2._0.Events;
using Khet2._0.Interfaces;
using Stylet;
using System;
using System.Diagnostics;
using System.Windows.Media;

namespace Khet2._0.MVVM.ViewModel
{
    public class SquareViewModel : Screen, IHandle<PieceSelectedEvent>, IHandle<PlayerChangeEvent>
    {
        private EventAggregator _eventAggregator;
        public Idx idx { get; set; }

        private LaserViewModel _ActiveLaser = new LaserViewModel();
        public LaserViewModel ActiveLaser { get => _ActiveLaser; set => SetAndNotify(ref _ActiveLaser, value); }

        private IPiece _ActivePiece;
        public IPiece ActivePiece { get => _ActivePiece; set { SetAndNotify(ref _ActivePiece, value); SetEnable(value); } }

        private Brush _highlight = Brushes.Transparent;
        public Brush highlight { get => _highlight; set => SetAndNotify(ref _highlight, value); }

        private bool _IsEnabled = false;
        public bool IsEnabled { get => _IsEnabled; set => SetAndNotify(ref _IsEnabled, value); }

        public SquareViewModel(EventAggregator eventAggregator, Idx index)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            this.idx = index;

        }

        public void ExecuteMouseDown()
        {
            Trace.WriteLine("SquareClicked!");

            _eventAggregator.Publish(new SquareClickEvent(this));
        }

        public void SelectSquare()
        {
            highlight = Brushes.Blue;
        }

        public void UnselectSquare()
        {
            highlight = Brushes.Transparent;
        }

        private void SetEnable(IPiece setPiece)
        {
            if (setPiece != null)
            {
                IsEnabled = true;
            }
            else
            {
                IsEnabled = false;
            }

        }

        public void Handle(PieceSelectedEvent e)
        {
            var rowDiff = Math.Abs(e.idx.row - idx.row);
            var colDiff = Math.Abs(e.idx.column - idx.column);

            if (rowDiff <= 1 && colDiff <= 1)
            {
                IsEnabled = true;
            }
            else
            {
                IsEnabled = false;
            }
        }

        public void Handle(PlayerChangeEvent e)
        {
            if (ActivePiece?.player == e.player)
            {
                IsEnabled = true;
            }
            else
            {
                IsEnabled = false;
            }
        }
    }
}
