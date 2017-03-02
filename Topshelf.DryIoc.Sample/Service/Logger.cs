using System.Reflection;

namespace Topshelf.DryIoc.Sample.Service
{
    public sealed class Logger : ILogger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public void Log(string message)
        {
            log.Info(message);
        }
    }
}