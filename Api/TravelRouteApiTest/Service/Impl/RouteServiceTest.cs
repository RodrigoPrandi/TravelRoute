using NSubstitute;
using NUnit.Framework;
using TravelRouteApi.Dto;
using TravelRouteApi.Repository.Impl;
using TravelRouteApi.Service.Impl;

namespace TravelRouteApiTest.Service.Impl
{
    class RouteServiceTest
    {
        private IRouteRepository repository;
        private RouteService routeService;

        [SetUp]
        public void SetUp()
        {
            repository = Substitute.For<IRouteRepository>();
            routeService = new RouteService(repository);
        }

        [Test]
        public void WhenSaveRouteValueThenSaveInRepository()
        {
            var routeValue = new RouteValue("FRO", "TO", 10);

            routeService.Save(routeValue);

            repository.Received().Save(routeValue);
        }
    }
}
