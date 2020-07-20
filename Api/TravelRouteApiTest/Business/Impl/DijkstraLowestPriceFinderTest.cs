using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TravelRouteApi.Business.Impl;
using TravelRouteApi.Business.Impl.Graph;
using TravelRouteApi.Dto;
using TravelRouteApi.Exceptions;
using TravelRouteApi.Repository.Impl;

namespace TravelRouteApiTest.Business.Impl
{
    class DijkstraLowestPriceFinderTest
    {
        private const string FROM = "ASD";
        private const string TO = "QWE";

        private IDijkstraImplementation dijkstraImplementation;
        private IRouteRepository routeRepository;
        private IGraphCreator graphCreator;
        private DijkstraLowestPriceFinder dijkstraLowestPriceFinder;

        [SetUp]
        public void SetUp()
        {
            routeRepository = Substitute.For<IRouteRepository>();
            graphCreator = Substitute.For<IGraphCreator>();
            dijkstraImplementation = Substitute.For<IDijkstraImplementation>();

            dijkstraLowestPriceFinder = new DijkstraLowestPriceFinder(routeRepository,graphCreator, dijkstraImplementation);
        }

        [Test]
        public void WhenExistsFromAndToDestinyThenFindByDijkstraImplementation()
        {
            var listRouteValue = new List<RouteValue>();
            routeRepository.GetAll().Returns(listRouteValue);

            var listNode = new List<Node>();

            var nodeFrom = new Node(FROM);
            var nodeTo = new Node(TO);
            listNode.Add(nodeFrom);
            listNode.Add(nodeTo);

            graphCreator.CreateNodes(listRouteValue).Returns(listNode);

            var bestRoute = new BestRoute();
            dijkstraImplementation.FindBestRoute(nodeFrom, nodeTo).Returns(bestRoute);

            var route = new Route(FROM, TO);
            var result = dijkstraLowestPriceFinder.Find(route);

            Assert.AreEqual(bestRoute, result);

            routeRepository.Received().GetAll();
            graphCreator.Received().CreateNodes(listRouteValue);
            dijkstraImplementation.Received().FindBestRoute(nodeFrom, nodeTo);
        }


        [Test]
        public void WhenNotExistsToDestinyThenReturnDestinyException()
        {
            var listRouteValue = new List<RouteValue>();
            routeRepository.GetAll().Returns(listRouteValue);

            var listNode = new List<Node>();

            var nodeFrom = new Node(FROM);
            listNode.Add(nodeFrom);

            graphCreator.CreateNodes(listRouteValue).Returns(listNode);


            var route = new Route(FROM, TO);

            var ex = Assert.Throws<DestinyException>(() => dijkstraLowestPriceFinder.Find(route));

            Assert.That(ex.Message, Is.EqualTo($"{TO}: Destination not registered!"));

            routeRepository.Received().GetAll();
            graphCreator.Received().CreateNodes(listRouteValue);
            dijkstraImplementation.DidNotReceive().FindBestRoute(Arg.Any<Node>(), Arg.Any<Node>());
        }


        [Test]
        public void WhenNotExistsFromDestinyThenReturnDestinyException()
        {
            var listRouteValue = new List<RouteValue>();
            routeRepository.GetAll().Returns(listRouteValue);

            var listNode = new List<Node>();

            var nodeTo = new Node(TO);
            listNode.Add(nodeTo);

            graphCreator.CreateNodes(listRouteValue).Returns(listNode);


            var route = new Route(FROM, TO);

            var ex = Assert.Throws<DestinyException>(() => dijkstraLowestPriceFinder.Find(route));

            Assert.That(ex.Message, Is.EqualTo($"{FROM}: Destination not registered!"));

            routeRepository.Received().GetAll();
            graphCreator.Received().CreateNodes(listRouteValue);
            dijkstraImplementation.DidNotReceive().FindBestRoute(Arg.Any<Node>(), Arg.Any<Node>());
        }

    }
}
