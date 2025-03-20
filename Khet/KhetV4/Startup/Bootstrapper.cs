using KhetV4.MVVM.ViewModels;
using Serilog;
using Stylet;
using StyletIoC;
using System;

namespace KhetV4.Startup
{
    public class Bootstrapper : Bootstrapper<ShellViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            ConfigureLogger();

            // Register Serilog logger in the IoC container
            builder.Bind<ILogger>().ToInstance(Log.Logger);

            // Register ViewModels
            builder.Bind<ToolbarViewModel>().ToSelf().InSingletonScope();

            // Register services
        }


        protected override void Configure()
        {
            // Perform any other configuration before the application starts
        }

        private void ConfigureLogger()
        {
            try
            {
                System.IO.File.Delete("..\\..\\..\\logs/log.txt");
            }
            catch (Exception e)
            {
                throw new Exception($"Log file cannot be deleted\n{e.Message}");
            }

            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.WithThreadId()
                .Enrich.FromLogContext() // Required for the caller info context properties

                .WriteTo.File(
                    path: "..\\..\\..\\logs/log.txt",
                    outputTemplate: "{Timestamp:dd-MM-yyyy HH:mm:ss} [{Level:u3}] Thread Id: {ThreadId} | File: {CallerFileName} | Function: {CallerMemberName} | Line Number: {CallerLineNumber}  - {Message} {NewLine}{Exception}"
                )
                .CreateLogger();
        }


    }
}
