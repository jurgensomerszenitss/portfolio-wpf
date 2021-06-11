using Mapster;
using MapsterMapper;
using System.Linq;

namespace PortDemo.Tests.Infrastructure
{
    public abstract class TestMapsBase : TestBase
    {
        public TestMapsBase()
        {
            var typeAdapterConfig = new TypeAdapterConfig();
            var mappingRegistrations = TypeAdapterConfig.GlobalSettings.Scan(typeof(App).Assembly);
            mappingRegistrations.ToList().ForEach(mr => mr.Register(typeAdapterConfig));
            Mapper = new Mapper(typeAdapterConfig);
        }

        protected Mapper Mapper { get; }
    }
}
