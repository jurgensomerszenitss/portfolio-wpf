using PortDemo.Domain;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace PortDemo.Data.Readers
{
    /// <summary>
    /// Reader for ethernet ports
    /// </summary>
    public class EthernetPortReader : IPortReader
    {
        public async Task<IList<PortInfo>> GetPorts()
        {
            var portInfo = new List<PortInfo>();
            var adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                portInfo.Add(CreatePortInfo(adapter));
            }

            return await Task.FromResult(portInfo);
        }

        private PortInfo CreatePortInfo(NetworkInterface networkInterface)
        {
            return new PortInfo
            {
                Name = networkInterface.Name,
                Status = MapStatus(networkInterface.OperationalStatus),
                Type = PortType.Ethernet
            };
        }

        private PortStatus MapStatus(OperationalStatus operationalStatus)
        {
            switch (operationalStatus)
            {
                case OperationalStatus.Up: return PortStatus.On;
                case OperationalStatus.Down: return PortStatus.Off;
                case OperationalStatus.Unknown: return PortStatus.Unknown;
                case OperationalStatus.Dormant:return PortStatus.Busy;
                default: return PortStatus.Unknown;
            }
        }

    }
}
