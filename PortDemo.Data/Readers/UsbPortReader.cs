using PortDemo.Domain;
using System.Collections.Generic;
using System.Management;
using System.Threading.Tasks;

namespace PortDemo.Data.Readers
{
    /// <summary>
    /// Reader for USB ports
    /// </summary>
    public class UsbPortReader : IPortReader
    {
        public async Task<IList<PortInfo>> GetPorts()
        {
            var portInfo = new List<PortInfo>();  
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
            {
                using (ManagementObjectCollection collection = searcher.Get())
                {
                    foreach (ManagementObject device in collection)
                    { 
                        portInfo.Add(CreatePortInfo(device));
                    }
                }
            }

            return await Task.FromResult(portInfo);
        }

        private PortInfo CreatePortInfo(ManagementObject device)
        {
            return new PortInfo
            {
                Name = device.GetPropertyValue("Name").ToString(),
               Status = MapStatus(device.GetPropertyValue("Status").ToString()),
                Type = PortType.Usb
            }; 
        }

        private PortStatus MapStatus(string portStatus)
        {
            switch (portStatus)
            {
                case "OK": return PortStatus.On;
                default: return PortStatus.Unknown;
            }
        }

    }
}
