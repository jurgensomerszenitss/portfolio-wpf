using NUnit.Framework;
using PortDemo.Domain;
using PortDemo.Tests.Infrastructure;
using AutoFixture;
using Mapster;
using PortDemo.ViewModels;

namespace PortDemo.Tests
{

    public class PortInfoRegistrationTests : TestMapsBase
    { 
        /// <summary>
        /// This test is using the AAA pattern (Assign-Act-Assert)
        /// </summary>
        [Test]
        public void When_Map_PortInfo_To_PortViewModel()
        {
            // assign
            var source = Fixture.Create<PortInfo>();

            // act 
            var actual = source.Adapt<PortViewModel>();

            // assert
            Assert.AreEqual(source.Name, actual.Name);
            Assert.AreEqual(source.Status, actual.Status);
            Assert.AreEqual(source.Type, actual.Type);
            Assert.Pass();
        }
    }
}