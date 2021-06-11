using PortDemo.Data.Readers;
using PortDemo.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortDemo.Data.Proxy
{
    /// <summary>
    /// The proxy is responsible to get the port info from multiple readers
    /// </summary>
    public class PortsProxy : IPortsProxy
    {
        public PortsProxy(Func<PortType, IPortReader> portsFactory)
        {
            _portsFactory = portsFactory;
        }

        private readonly Func<PortType, IPortReader> _portsFactory;

        public async Task<IList<PortInfo>> GetPorts(PortType portTypes = PortType.Usb | PortType.Ethernet)
        {
            var portInfo = new List<PortInfo>();
            foreach (Enum value in Enum.GetValues(portTypes.GetType()))
            {
                if (portTypes.HasFlag(value))
                { 
                    var portReader = _portsFactory.Invoke((PortType)value);
                    portInfo.AddRange(await portReader.GetPorts());
                }
            }

            return portInfo;
        }
    }
}
