using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TravelRouteApi.Exceptions;

namespace TravelRouteApiTest.Exceptions
{
    class RouteExceptionTest
    {
        [Test]
        public void TestDestinyExceptionMessage()
        {
            var destinyException = new RouteException("ORI", "DES");
            Assert.AreEqual("Route cannot be found between ORI and DES!", destinyException.Message);
            Assert.IsTrue(destinyException is BusinessException);
        }
    }
}
