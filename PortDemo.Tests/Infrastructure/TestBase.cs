using AutoFixture;
using AutoFixture.AutoMoq;

namespace PortDemo.Tests.Infrastructure
{
    public abstract class TestBase
    {
        public TestBase()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());

        }

        protected IFixture Fixture { get; }
    }
}
