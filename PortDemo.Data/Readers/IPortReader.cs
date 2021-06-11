using PortDemo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortDemo.Data.Readers
{
    /// <summary>
    /// Blueprint of a port reader
    /// </summary>
    public interface IPortReader
    {
        Task<IList<PortInfo>> GetPorts();
    }
}
