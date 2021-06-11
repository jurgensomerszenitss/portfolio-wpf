using PortDemo.Domain;
using System;
namespace PortDemo.Data.Readers
{
    /// <summary>
    /// This is a factory pattern, as we have multiple implementations for the IPortReader and we need to load
    /// the requested portreader. 
    /// This allows to extend to more different port readers in the future
    /// </summary>
    public static class PortReaderFactory
    {
        public static IPortReader Create(PortType portType)
        {
            switch (portType)
            {
                case PortType.Ethernet: return new EthernetPortReader();
                case PortType.Usb: return new UsbPortReader();
            }

            throw new ArgumentOutOfRangeException("Unsupported port type");
        }
    }
}
