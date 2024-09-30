using Khet2._0.MVVM.Models;
using Khet2._0.MVVM.ViewModel;
using Khet2._0.Pages;
using Stylet;
using StyletIoC;
using System;

namespace Khet2._0
{
    public class Bootstrapper : Bootstrapper<ShellViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Configure the IoC container in here
            builder.Bind<EventAggregator>().ToSelf().InSingletonScope();
            builder.Bind<ShellViewModel>().ToSelf().InSingletonScope();
            builder.Bind<GameViewModel>().ToSelf();
            builder.Bind<HomeViewModel>().ToSelf();
            builder.Bind<BoardViewModel>().ToSelf();
            builder.Bind<RotateModel>().ToSelf();
            builder.Bind<GameModel>().ToSelf();
        }

        protected override void Configure()
        {
            var gameModel = this.Container.Get<GameModel>();
        }

    }
}
