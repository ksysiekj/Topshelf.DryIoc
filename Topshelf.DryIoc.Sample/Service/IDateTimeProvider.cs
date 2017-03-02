using System;

namespace Topshelf.DryIoc.Sample.Service
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}