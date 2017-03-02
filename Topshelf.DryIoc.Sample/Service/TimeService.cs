using System;
using System.Timers;

namespace Topshelf.DryIoc.Sample.Service
{
    public sealed class ItemService
    {
        private readonly ILogger _logger;
        private readonly Timer _timer;

        public ItemService(ILogger logger)
        {
            _logger = logger;
            _timer = new Timer(5000) { AutoReset = true, };
            _timer.Elapsed += (sender, e) =>
            {
                _logger.Log("Processing item: Id=" + Guid.NewGuid().ToString("D"));
            };
        }

        public bool Start(HostControl hostControl)
        {
            _logger.Log("Service started...");
            _timer.Start();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _logger.Log("Service stopped...");
            _timer.Stop();

            return true;
        }
    }
}
