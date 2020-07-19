using TravelRouteConsole;
using NUnit.Framework;
using System;
using TravelRouteConsole.IoC;
using TravelRouteConsole.Contoller;
using NSubstitute;

namespace TravelRouteConsoleTest
{
    public class ProgramTest
    {
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
            var travelRouteControllerMock = Substitute.For<TravelRouteController>();

            RegisterIoC.KernelIoC.Rebind<TravelRouteController>().ToConstant(travelRouteControllerMock);

            Program.Main(new string[] { paramter });

            travelRouteControllerMock.Received(2).Initialize(paramter);
        }
    }
}