using AutoFixture;
using Moq;
using NUnit.Framework;
using PortDemo.Data.Proxy;
using PortDemo.Domain;
using PortDemo.Infrastructure;
using PortDemo.Tests.Infrastructure;
using PortDemo.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortDemo.Tests.ViewModels
{
    public class MasterViewModelTests : TestBase
    {
        [Test]
        public void When_Load()
        {
            // assign
            var mockPortProxy = Fixture.Freeze<Mock<IPortsProxy>>(); // we setup a dependency (the proxy) to return some mock data for further testing the logic in the viewmodel
            mockPortProxy.Setup(x => x.GetPorts(It.IsAny<PortType>())).Returns(Task.FromResult((IList<PortInfo>) new List<PortInfo>(Fixture.CreateMany<PortInfo>())));
            var sut = Fixture.Create<MasterViewModel>();

            // act
            ((RelayCommand) sut.LoadCommand).ExecuteAsync().Wait(); // we have to parse here to wait for the async to finish


            // assert
            Assert.IsNotNull(sut.Ports);
            Assert.IsNotEmpty(sut.Ports);
            mockPortProxy.Verify(x => x.GetPorts(It.IsAny<PortType>()), Times.Once); // we test here if the proxy was called exactly 1 time
        }
    }
}
