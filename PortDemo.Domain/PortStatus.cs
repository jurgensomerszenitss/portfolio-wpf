using System;

namespace PortDemo.Domain
{
    [Flags]
    public enum PortStatus
    {
        Unknown = 1 << 0,
        On = 1 << 0,
        Off = 1 << 1,
        Busy = 1 << 2,
        Error = 1 << 3, 
    }
}
