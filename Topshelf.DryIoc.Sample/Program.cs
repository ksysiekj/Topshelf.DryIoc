using DryIoc;
using System;
using Topshelf.DryIoc.Extensions;
using Topshelf.DryIoc.Sample.Service;

namespace Topshelf.DryIoc.Sample
{
    static class Program
    {
        private static readonly ILogger _logger = new Logger();

        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            ConfigureService();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            _logger.Log(sender.ToString() + " : " + e.ExceptionObject.ToString());
        }

        private static void ConfigureService()
        {
            // create container
            IContainer container = new Container();
            container.RegisterDependencies();

            HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.UseDryIocContainer(container);

                hostConfigurator.Service<ItemService>(s =>
                {
                    s.ConstructUsingDryIocContainer();

                    s.WhenStarted((service, control) => service.Start(control));
                    s.WhenStopped((service, control) => service.Stop(control));
                });

                hostConfigurator.SetServiceName("SampleTimeService");
                hostConfigurator.SetDisplayName("DryIocTopShelfSampleTimeService");
                hostConfigurator.SetDescription("SampleTimeService showing how to use DryIoc with TopShelf");

                hostConfigurator.RunAsLocalSystem();
            });
        }

        private static void RegisterDependencies(this IContainer container)
        {
            container.Register<IDateTimeProvider, DateTimeProvider>();
            container.Register<ItemService>();
            container.Register<ILogger, Logger>();
            container.Register<ILogger, DateTimeLogger>(setup: Setup.Decorator);
        }
    }
}
