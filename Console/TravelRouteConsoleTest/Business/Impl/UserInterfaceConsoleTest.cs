using NSubstitute;
using NUnit.Framework;
using System;
using System.IO;
using TravelRouteConsole.Business.Impl;
using TravelRouteConsole.Dto;
using TravelRouteConsole.Factory;

namespace TravelRouteConsoleTest.Business.Impl
{
    class UserInterfaceConsoleTest
    {
        private UserInterfaceConsole userInterfaceConsole;
        private Route expectedRoute;
        private IRouteFactory routeFactory;

        [SetUp]
        public void SetUp()
        {
            expectedRoute = new Route("GRU", "ASD");
            routeFactory = Substitute.For<IRouteFactory>();

            routeFactory.Create("GRU-ASD").Returns(expectedRoute);

            userInterfaceConsole = new UserInterfaceConsole(routeFactory);
        }

        [Test]
        public void TestConsoleReadRoute()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("GRU-ASD");
            Console.SetIn(input);

            var response = userInterfaceConsole.GetRoute();

            routeFactory.Received().Create("GRU-ASD");

            Assert.That(output.ToString(), Is.EqualTo(string.Format("Please enter the route: ", Environment.NewLine)));
            Assert.AreEqual(expectedRoute, response);
        }

        [Test]
        public void TestConsolePrintBestRouteMessage()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var bestRoute = new BestRoute { Route = "ASD-AQW-QWE", Value = 10 };

            userInterfaceConsole.PrintBestRoute(bestRoute);

            Assert.AreEqual($"best route: ASD-AQW-QWE > $10{Environment.NewLine}", output.ToString());
        }

        [Test]
        public void TestConsolePrintExceptionMessage()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var exceptionMessage = "Error message!!";
            var exception = new Exception(exceptionMessage);

            userInterfaceConsole.PrintException(exception);

            Assert.AreEqual($"ERRO: {exceptionMessage}{Environment.NewLine}", output.ToString());
        }

    }
}
