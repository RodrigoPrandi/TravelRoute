using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelRouteApi.Business.Impl;
using TravelRouteApi.Business.Impl.Graph;
using TravelRouteApi.Exceptions;

namespace TravelRouteApiTest.Business.Impl
{
    class DijkstraImplementationTest
    {
        private List<Node> listNodes;
        private DijkstraImplementation dijkstraImplementatio;

        [SetUp]
        public void SetUp()
        {
            CreateSampleNodes();
            dijkstraImplementatio = new DijkstraImplementation();
        }

        [Test]
        public void TestRouteFromGRUToCDG()
        {
            var from = listNodes.FirstOrDefault(x => x.Label == "GRU");
            var to = listNodes.FirstOrDefault(x => x.Label == "CDG");

            var result = dijkstraImplementatio.FindBestRoute(from, to);

            Assert.AreEqual(40, result.Value);
            Assert.AreEqual("GRU - BRC - SCL - ORL - CDG", result.Route);
        }

        [Test]
        public void TestRouteFromBRCToCDG()
        {
            var from = listNodes.FirstOrDefault(x => x.Label == "BRC");
            var to = listNodes.FirstOrDefault(x => x.Label == "CDG");

            var result = dijkstraImplementatio.FindBestRoute(from, to);

            Assert.AreEqual(30, result.Value);
            Assert.AreEqual("BRC - SCL - ORL - CDG", result.Route);
        }

        [Test]
        public void TestRouteFromGRUToSCL()
        {
            var from = listNodes.FirstOrDefault(x => x.Label == "GRU");
            var to = listNodes.FirstOrDefault(x => x.Label == "SCL");

            var result = dijkstraImplementatio.FindBestRoute(from, to);

            Assert.AreEqual(15, result.Value);
            Assert.AreEqual("GRU - BRC - SCL", result.Route);
        }

        [Test]
        public void TestRouteFromGRUToORL()
        {
            var from = listNodes.FirstOrDefault(x => x.Label == "GRU");
            var to = listNodes.FirstOrDefault(x => x.Label == "ORL");

            var result = dijkstraImplementatio.FindBestRoute(from, to);

            Assert.AreEqual(35, result.Value);
            Assert.AreEqual("GRU - BRC - SCL - ORL", result.Route);
        }


        [Test]
        public void TestRouteFromBRCToSCL()
        {
            var from = listNodes.FirstOrDefault(x => x.Label == "BRC");
            var to = listNodes.FirstOrDefault(x => x.Label == "SCL");

            var result = dijkstraImplementatio.FindBestRoute(from, to);

            Assert.AreEqual(5, result.Value);
            Assert.AreEqual("BRC - SCL", result.Route);
        }

        [Test]
        public void TestRouteFromSCLToBRC()
        {
            var from = listNodes.FirstOrDefault(x => x.Label == "SCL");
            var to = listNodes.FirstOrDefault(x => x.Label == "BRC");

            var result = dijkstraImplementatio.FindBestRoute(from, to);

            Assert.AreEqual(5, result.Value);
            Assert.AreEqual("SCL - BRC", result.Route);
        }

        [Test]
        public void TestRouteFromORLToORL()
        {
            var from = listNodes.FirstOrDefault(x => x.Label == "ORL");
            var to = listNodes.FirstOrDefault(x => x.Label == "ORL");

            var ex = Assert.Throws<RouteException>(() => dijkstraImplementatio.FindBestRoute(from, to));

            Assert.That(ex.Message, Is.EqualTo("Route cannot be found between ORL and ORL!"));
        }

        private void CreateSampleNodes()
        {
            var nodeGRU = new Node("GRU");
            var nodeBRC = new Node("BRC");
            var nodeSCL = new Node("SCL");
            var nodeORL = new Node("ORL");
            var nodeCDG = new Node("CDG");

            nodeGRU.ConnectTo(nodeCDG, 75);
            nodeGRU.ConnectTo(nodeBRC, 10);
            nodeGRU.ConnectTo(nodeSCL, 20);
            nodeGRU.ConnectTo(nodeORL, 56);

            nodeBRC.ConnectTo(nodeSCL, 5);
            nodeSCL.ConnectTo(nodeORL, 20);
            nodeORL.ConnectTo(nodeCDG, 5);

            listNodes = new List<Node> { nodeBRC, nodeCDG, nodeGRU, nodeORL, nodeSCL };
        }
    }
}
