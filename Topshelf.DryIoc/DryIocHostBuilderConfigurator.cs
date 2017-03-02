using DryIoc;
using System;
using System.Collections.Generic;
using Topshelf.Builders;
using Topshelf.Configurators;
using Topshelf.HostConfigurators;

namespace Topshelf.DryIoc
{
    public sealed class DryIocHostBuilderConfigurator : HostBuilderConfigurator
    {
        public DryIocHostBuilderConfigurator(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            Container = container;
        }

        public static IContainer Container { get; private set; }

        public HostBuilder Configure(HostBuilder builder)
        {
            return builder;
        }

        public IEnumerable<ValidateResult> Validate()
        {
            yield break;
        }
    }
}
