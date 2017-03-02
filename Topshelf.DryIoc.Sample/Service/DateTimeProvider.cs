using System;

namespace Topshelf.DryIoc.Sample.Service
{
    public sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}