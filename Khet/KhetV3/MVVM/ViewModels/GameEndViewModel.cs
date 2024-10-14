using Khet3.Enums;
using Khet3.Events;
using Stylet;

namespace KhetV3.MVVM.ViewModels
{
    public class GameEndViewModel : Screen
    {
        EventAggregator _EventAggregator;
        public GameEndViewModel(EventAggregator eventAggregator)
        {
            _EventAggregator = eventAggregator;
        }

        public void ClosePopup()
        {
            this.RequestClose(true);

        }


        public void ExecuteHomeButton()
        {
            this.RequestClose(true);
            _EventAggregator.Publish(new NavigateEvent { page = AppPages.Home });
        }
    }
}
