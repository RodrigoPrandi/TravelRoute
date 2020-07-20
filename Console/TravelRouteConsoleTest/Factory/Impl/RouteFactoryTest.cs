using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelRouteConsole.Factory.Impl;

namespace TravelRouteConsoleTest.Factory.Impl
{
    class RouteFactoryTest
    {
        private RouteFactory routeFactory;

        [SetUp]
        public void SetUp()
        {
            routeFactory = new RouteFactory();
        }

        [Test]
        public void WhenCreateWithValidFormatThenReturnRoute()
        {
            var from = RandomString(3);
            var to = RandomString(3);
            var result = routeFactory.Create($"{from}-{to}");

            Assert.AreEqual(from, result.From);
            Assert.AreEqual(to, result.To);
        }

        [Test]
        public void WhenCreateWithInValidFormatThenReturnException()
        {
            var invalidFormatList = new List<string> { 
                "", 
                "asdf",
                "asd-qwe",
                "asd - qwe",
                "ASD - AWR",
                "AERS-AWE",
                "AER-AWED"
            };

            foreach (var invalidFormat in invalidFormatList)
            {
                var ex = Assert.Throws<Exception>(() => routeFactory.Create(invalidFormat));

                Assert.That(ex.Message, Is.EqualTo("Invalid route format! The format valid is \"XXX-XXX\"."));
            }
        }

        public static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
