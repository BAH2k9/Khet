using Khet3.Enums;
using Khet3.Events;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.MVVM.ViewModels
{


    public class HomeButtonViewModel : Screen
    {
        private EventAggregator _eventAggregator;

        private float _HomeButtonOpacity;
        public float HomeButtonOpacity { get => _HomeButtonOpacity; set => SetAndNotify(ref _HomeButtonOpacity, value); }

        public bool IsEnabled = true;

        public HomeButtonViewModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            HomeButtonOpacity = 0.5f;
        }

        public async Task ExecuteHomeButton()
        {
            if (IsEnabled)
            {
                await Task.Delay(200);

                _eventAggregator.Publish(new NavigateEvent { page = AppPages.Home });
            }

        }

        public void OnMouseEnterHomeButton()
        {
            HomeButtonOpacity = 1.0f;
        }

        public void OnMouseLeaveHomeButton()
        {
            HomeButtonOpacity = 0.5f;
        }

        internal void GiveReference(GameViewModel gameViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
