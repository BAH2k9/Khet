using KhetV4.Core.ExtensionMethods;
using Serilog;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV4.MVVM.ViewModels
{
    public class HomeViewModel : Screen
    {
        ILogger _logger;
        public HomeViewModel(ILogger logger)
        {
            _logger = logger;
            _logger.InformationWithCaller("HomeViewModel created");
        }

        public void NavigateToFreePlay()
        {
            _logger.InformationWithCaller("Navigate to Free Play button pressed");
        }

        public void NavigateToPlayGame()
        {
            _logger.InformationWithCaller("Navigate to Play Game button pressed");
        }

        public void NavigateToLanGame()
        {
            _logger.InformationWithCaller("Navigate to LAN Game button pressed");
        }
    }
}
