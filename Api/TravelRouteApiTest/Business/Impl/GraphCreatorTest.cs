using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TravelRouteApi.Business.Impl;
using TravelRouteApi.Dto;

namespace TravelRouteApiTest.Business.Impl
{
    class GraphCreatorTest
    {
        private const string FROM = "ASD";
        private const string TO = "QWE";
        private const int VALUE = 12;

        private List<RouteValue> routes;
        private GraphCreator graphCreator;

        [SetUp]
        public void SetUp()
        {
            var routeValue = new RouteValue(FROM, TO, VALUE);
            routes = new List<RouteValue> { routeValue };

            graphCreator = new GraphCreator();
        }

        [Test]
        public void TestGraphCreator()
        {
            Assert.IsTrue(routes.Count == 1);

            var result = graphCreator.CreateNodes(routes);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 2);

            var nodeFrom = result.FirstOrDefault(x => x.Label == FROM);

            Assert.IsNotNull(nodeFrom);
            Assert.AreEqual(1, nodeFrom.Neighbors.Count());
            Assert.AreEqual(1, nodeFrom.Edges.Count());


            var nodeTo = result.FirstOrDefault(x => x.Label == TO);
            Assert.IsNotNull(nodeTo);
            Assert.AreEqual(1, nodeTo.Neighbors.Count());
            Assert.AreEqual(1, nodeTo.Edges.Count());
            Assert.AreEqual(1, nodeTo.Edges.Count());


            var edgeFrom = nodeFrom.Edges.First();
            var edgeTo = nodeTo.Edges.First();

            Assert.AreEqual(VALUE, edgeFrom.Value);
            Assert.AreEqual(nodeFrom, edgeFrom.Node1);
            Assert.AreEqual(nodeTo, edgeFrom.Node2);
            Assert.AreEqual(edgeFrom, edgeTo);

            var neighborsFrom = nodeFrom.Neighbors.First();
            var neighborsTo = nodeTo.Neighbors.First();

            Assert.AreEqual(VALUE, neighborsTo.WeightToNode);
            Assert.AreEqual(neighborsFrom.WeightToNode, neighborsTo.WeightToNode);
            Assert.AreEqual(neighborsFrom.Node, nodeTo);
            Assert.AreEqual(neighborsTo.Node, nodeFrom);

        }
    }
}
