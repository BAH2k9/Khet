using Khet.Wpf.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Khet.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainVM = new MainViewModel();
            var mainWindow = new MainWindow() { DataContext = mainVM };

            mainWindow.Show();          
        }
    }

}
