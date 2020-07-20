using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TravelRouteApi.Dto;
using TravelRouteApi.Repository.Impl;

namespace TravelRouteApiTest.Repository.Impl
{
    class InMemoryRouteRepositoryTest
    {
        private InMemoryRouteRepository inMemoryRouteRepository;

        [SetUp]
        public void SetUp()
        {
            inMemoryRouteRepository = new InMemoryRouteRepository();
        }

        [Test]
        public void AddRouteValue()
        {
            var routeValue = new RouteValue("FRO", "TOO", 10);

            inMemoryRouteRepository.Save(routeValue);

            var allRoutes = inMemoryRouteRepository.GetAll();

            Assert.AreEqual(1, allRoutes.Count);
            Assert.IsTrue(allRoutes.Exists(x => x.From == routeValue.From && x.To == routeValue.To && x.Value== routeValue.Value));

        }
    }
}
