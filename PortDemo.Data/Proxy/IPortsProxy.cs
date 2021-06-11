using PortDemo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortDemo.Data.Proxy
{
    public interface IPortsProxy
    {
        Task<IList<PortInfo>> GetPorts(PortType portTypes = PortType.Usb | PortType.Ethernet);
    }
}
