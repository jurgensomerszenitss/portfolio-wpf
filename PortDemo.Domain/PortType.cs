using System;

namespace PortDemo.Domain
{
    [Flags]
    public enum PortType
    {
        Unknown = 1 << 0,
        Usb = 1 << 1,
        Ethernet = 1 << 2
    }
}
