using Khet2._0.CustomTypes;
using Khet2._0.Events;
using Khet2._0.Interfaces;
using Stylet;
using System;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;

namespace Khet2._0.MVVM.ViewModel
{
    public class SquareViewModel : Screen, IHandle<PieceSelectedEvent>, IHandle<PlayerChangeEvent>, IHandle<PieceMovedEvent>, IHandle<PieceUnselectedEvent>, IHandle<PieceRotatedEvent>
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

            Keyboard.Focus(this.View);

            _eventAggregator.Publish(new SquareClickEvent(this));
        }

        public void ExecuteKeyDown(KeyEventArgs e)
        {
            Trace.WriteLine($"Key {e.Key} pressed!");

            e.Handled = true;

            if (e.Key == Key.Left || e.Key == Key.Right)
            {
                _eventAggregator.Publish(new PieceRotateEvent(this, e.Key));
            }

        }

        public void SelectSquare()
        {
            highlight = Brushes.Blue;
        }

        public void UnselectSquare()
        {
            highlight = Brushes.Transparent;
        }

        private void SetEnable(IPiece myPiece)
        {
            if (myPiece != null)
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
            if (HavePiece())
            {
                if (ActivePiece.player == e.player)
                {
                    IsEnabled = true;
                }
                else
                {
                    IsEnabled = false;
                }
            }

        }

        private bool HavePiece()
        {
            if (ActivePiece == null)
            {
                return false;
            }

            return true;
        }

        public void Handle(PieceMovedEvent e)
        {
            IsEnabled = false;
        }

        public void Handle(PieceRotatedEvent e)
        {
            IsEnabled = false;
        }

        public void Handle(PieceUnselectedEvent e)
        {
            if (HavePiece())
            {
                if (ActivePiece.player == e.playerTurn)
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
}
