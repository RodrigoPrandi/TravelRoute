using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TravelRouteApi.Business;
using TravelRouteApi.Business.Impl;

namespace TravelRouteApiTest.Business.Impl
{
    class FindFactoryTest
    {
        private ILowestPriceFinder lowestPriceFinder;
        private FindFactory findFactory;

        [SetUp]
        public void SetUp()
        {
            lowestPriceFinder = Substitute.For<ILowestPriceFinder>();
            findFactory = new FindFactory(lowestPriceFinder);
        }

        [Test]
        public void WhenGetFinderWithValueThenReturnLowestPriceFinder()
        {
            var result = findFactory.GetFinder(FindBestBy.VALUE);

            Assert.AreEqual(lowestPriceFinder, result);
        }

        [Test]
        public void WhenGetFinderWithScaleThenReturnNotImplementedException()
        {
            var ex = Assert.Throws<NotImplementedException>(() => findFactory.GetFinder(FindBestBy.SCALE));

            Assert.That(ex.Message, Is.EqualTo("Other searches not implemented!"));
        }
    }
}
