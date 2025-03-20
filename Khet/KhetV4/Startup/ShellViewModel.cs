using KhetV4.Core.ExtensionMethods;
using KhetV4.MVVM.ViewModels;
using Serilog;
using Stylet;

namespace KhetV4.Startup
{
    public class ShellViewModel : Screen
    {
        public ToolbarViewModel ToolBarViewModel { get; }
        public Screen DisplayViewModel { get; }

        HomeViewModel _homeVM;
        ILogger _logger;

        public ShellViewModel(ILogger logger, ToolbarViewModel toolBarVM, HomeViewModel homeVM)
        {
            _logger = logger;
            _logger.InformationWithCaller("ShellViewModel created");
            ToolBarViewModel = toolBarVM;
            _homeVM = homeVM;

            DisplayViewModel = _homeVM;
        }
    }
}
