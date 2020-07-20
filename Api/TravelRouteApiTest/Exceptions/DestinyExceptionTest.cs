using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TravelRouteApi.Exceptions;

namespace TravelRouteApiTest.Exceptions
{
    class DestinyExceptionTest
    {
        [Test]
        public void TestDestinyExceptionMessage()
        {
            var destinyException = new DestinyException("DES");
            Assert.AreEqual("DES: Destination not registered!", destinyException.Message);
            Assert.IsTrue(destinyException is BusinessException);
        }
    }
}
