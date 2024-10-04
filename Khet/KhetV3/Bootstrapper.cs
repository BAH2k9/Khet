using KhetV3.MVVM.ViewModels;
using KhetV3.Pages;
using KhetV3.Services;
using Stylet;
using StyletIoC;

namespace KhetV3
{
    public class Bootstrapper : Bootstrapper<ShellViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Configure the IoC container in here
            builder.Bind<EventAggregator>().ToSelf().InSingletonScope();
            builder.Bind<ShellViewModel>().ToSelf().InSingletonScope();
            builder.Bind<BoardUpdateService>().ToSelf().InSingletonScope();
            builder.Bind<GameViewModel>().ToSelf();
            builder.Bind<HomeViewModel>().ToSelf();
            builder.Bind<BoardViewModel>().ToSelf();
        }

        protected override void Configure()
        {
            // Perform any other configuration before the application starts
        }
    }
}
