using Khet2._0.CustomTypes;
using Khet2._0.Events;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet2._0.MVVM.Models
{
    public class GamePlayModel : IHandle<PlayerChangeEvent>
    {
        private MyGrid _grid;
        private EventAggregator _eventAggregator;
        public int player { get; set; }
        public GamePlayModel(EventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);

        }

        private void BeginGame()
        {
            _eventAggregator.Publish(new PlayerChangeEvent(1));
        }

        public void SetGrid(MyGrid grid)
        {
            _grid = grid;
        }

        public void Handle(PlayerChangeEvent e)
        {
            this.player = e.player;
        }
    }
}
