using KhetV4.Core.Enums;
using KhetV4.Core.ExtensionMethods;
using KhetV4.MVVM.ViewModels;
using Serilog;
using Stylet;
using System;

namespace KhetV4.Startup
{
    public class ShellViewModel : Screen
    {
        public ToolbarViewModel ToolBarViewModel { get; }

        Screen _displayViewModel;
        public Screen DisplayViewModel { get => _displayViewModel; set => SetAndNotify(ref _displayViewModel, value); }

        HomeViewModel _homeVM;
        Func<FreePlayViewModel> _freePlayVMFactory;
        ILogger _logger;

        public ShellViewModel(ILogger logger, ToolbarViewModel toolBarVM, HomeViewModel homeVM, Func<FreePlayViewModel> freePlayVMFactory)
        {
            _logger = logger;
            _logger.InformationWithCaller("ShellViewModel created");
            ToolBarViewModel = toolBarVM;
            _homeVM = homeVM;
            _homeVM.NavigateCallback = Navigate;
            _freePlayVMFactory = freePlayVMFactory;

            DisplayViewModel = _homeVM;
        }

        void Navigate(Pages page)
        {
            switch (page)
            {
                case Pages.FreePlay:
                    DisplayViewModel = _freePlayVMFactory();
                    break;
                case Pages.PlayGame:
                    break;
                case Pages.LanGame:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
