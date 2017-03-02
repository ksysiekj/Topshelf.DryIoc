namespace Topshelf.DryIoc.Sample.Service
{
    public sealed class DateTimeLogger : ILogger
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ILogger _logger;

        public DateTimeLogger(IDateTimeProvider dateTimeProvider, ILogger logger)
        {
            _dateTimeProvider = dateTimeProvider;
            _logger = logger;
        }

        public void Log(string message)
        {
            _logger.Log($"[{_dateTimeProvider.Now}]\t{message}");
        }
    }
}