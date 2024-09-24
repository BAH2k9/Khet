using Khet2._0.Enums;
using Khet2._0.Events;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet2._0.MVVM.ViewModel
{
    public class HomeViewModel : Screen
    {
        private EventAggregator _eventAggregator;

        public HomeViewModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        public void NavigateToGameView()
        {
            _eventAggregator.Publish(new NavigateEvent { page = AppPages.Game });
        }
    }


}
