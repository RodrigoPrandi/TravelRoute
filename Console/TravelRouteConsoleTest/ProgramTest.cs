using TravelRouteConsole;
using NUnit.Framework;
using System;
using TravelRouteConsole.IoC;
using TravelRouteConsole.Business;
using NSubstitute;

namespace TravelRouteConsoleTest
{
    public class ProgramTest
    {
        [SetUp]
        [Test]
        public void WhenSendEmptyArgumentThenReturnArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Program.Main(Array.Empty<string>()));

            Assert.That(ex.Message, Is.EqualTo("Please enter a csv file."));
        }

        [Test]
        public void WhenSendMoreThenOneArgumentThenReturnArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Program.Main(new string[]{"first", "second"}));

            Assert.That(ex.Message, Is.EqualTo("Only one argument should be informed."));
        }

        [Test]
        public void WhenSendOnlyOneArgumentThenInitializeProgram()
        {
            var paramter = "first";
            var travelRouteControllerMock = Substitute.For<ITravelRouteController>();

            RegisterIoC.KernelIoC.Rebind<ITravelRouteController>().ToConstant(travelRouteControllerMock);

            Program.Main(new string[] { paramter });

            travelRouteControllerMock.Received().Initialize(paramter);
        }
    }
}