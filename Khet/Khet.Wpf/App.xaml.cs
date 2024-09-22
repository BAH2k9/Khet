using Khet.Wpf.Models;
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

            MoveModel moveModel = new MoveModel();
            GridModel gridModel = GridModel.Create();
            BoardConfiguration boardConfiguration = new BoardConfiguration(gridModel);


            var boardViewModel = new BoardViewModel(moveModel, boardConfiguration);

            var mainViewModel = new MainViewModel(boardViewModel);

            var mainWindow = new MainWindow() { DataContext = mainViewModel };

            mainWindow.Show();          
        }
    }

}
