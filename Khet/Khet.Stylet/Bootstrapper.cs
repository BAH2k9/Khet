using Khet.Stylet.MVVM.Models;
using Khet.Stylet.MVVM.ViewModels;
using Khet.Stylet.Pages;
using Stylet;
using StyletIoC;
using System.Reflection;

namespace Khet.Stylet
{
    public class Bootstrapper : Bootstrapper<ShellViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Configure the IoC container in here
            // Add the assembly containing your ViewModels
            builder.Assemblies.Add(Assembly.GetExecutingAssembly());

            // Register your ViewModel
            builder.Bind<ShellViewModel>().ToSelf().InSingletonScope();
            builder.Bind<BoardViewModel>().ToSelf();

            // Register Models/services
            builder.Bind<MoveModel>().ToSelf();
            builder.Bind<BoardConfigurationModel>().ToSelf();


            // Register Core components
            builder.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();


        }

        protected override void Configure()
        {
            // Perform any other configuration before the application starts
        }
    }
}
