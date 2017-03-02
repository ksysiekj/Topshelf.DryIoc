﻿using DryIoc;
using Topshelf.HostConfigurators;

namespace Topshelf.DryIoc.Extensions
{
    public static class HostConfiguratorExtensions
    {
        public static HostConfigurator UseDryIocContainer(this HostConfigurator configurator, IContainer container)
        {
            configurator.AddConfigurator(new DryIocHostBuilderConfigurator(container));
            return configurator;
        }
    }
}
