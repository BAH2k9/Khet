using Khet.Stylet.MVVM.ViewModels;
using Stylet;

namespace Khet.Stylet.Pages
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public ShellViewModel(BoardViewModel boardViewModel)
        {
            ActiveItem = boardViewModel;
        }

    }
}
