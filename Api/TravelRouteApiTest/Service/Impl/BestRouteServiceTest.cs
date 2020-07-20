using NSubstitute;
using NUnit.Framework;
using TravelRouteApi.Business;
using TravelRouteApi.Dto;
using TravelRouteApi.Service.Impl;

namespace TravelRouteApiTest.Service.Impl
{
    class BestRouteServiceTest
    {
        private IFindFactory findFactory;
        private IBestRouteFinder bestRoutFinder;
        private BestRouteService bestRouteService;

        [SetUp]
        public void SetUp()
        {
            findFactory = Substitute.For<IFindFactory>();
            bestRoutFinder = Substitute.For<IBestRouteFinder>();
            bestRouteService = new BestRouteService(findFactory);
        }

        [Test]
        public void WhenCalcBestRoutThenGetFinderWithValueAndFindRoute()
        {
            var route = new Route("FRO", "TO");

            var bestRoute = new BestRoute();

            bestRoutFinder.Find(route).Returns(bestRoute);

            findFactory.GetFinder(FindBestBy.VALUE).Returns(bestRoutFinder);

            var result = bestRouteService.CalcBestRoute(route);

            findFactory.Received().GetFinder(FindBestBy.VALUE);
            bestRoutFinder.Received().Find(route);

            Assert.AreEqual(bestRoute, result);
        }
    }
}
