using PortDemo.Data.Proxy;
using PortDemo.Data.Readers;
using PortDemo.Domain;
using SimpleInjector;
using System;

namespace PortDemo.Data
{
    public static class Bootstrapper
    {
        public static Container BootstrapData(this Container container)
        {
            container.RegisterSingleton<IPortsProxy, PortsProxy>();
            container.RegisterInstance<Func<PortType, IPortReader>>((PortType portType) => PortReaderFactory.Create(portType));
            return container;
        }
    }
}
