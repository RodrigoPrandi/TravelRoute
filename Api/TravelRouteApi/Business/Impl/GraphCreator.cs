
using System.Collections.Generic;
using System.Linq;
using TravelRouteApi.Business.Impl.Graph;
using TravelRouteApi.Dto;

namespace TravelRouteApi.Business.Impl
{
    class GraphCreator : IGraphCreator
    {
        public List<Node> CreateNodes(List<RouteValue> routes)
        {
            var nodeList = new List<Node>();

            routes.ForEach(route =>
            {
                var nodeFrom = nodeList.FirstOrDefault(node => node.Label == route.From);
                var nodeTo = nodeList.FirstOrDefault(node => node.Label == route.To);

                if (nodeFrom == null)
                {
                    nodeFrom = new Node(route.From);
                    nodeList.Add(nodeFrom);
                }

                if (nodeTo == null)
                {
                    nodeTo = new Node(route.To);
                    nodeList.Add(nodeTo);
                }

                nodeFrom.ConnectTo(nodeTo, route.Value);

            });

            return nodeList;
        }
    }
}
