using System.Collections.Generic;
using System.Linq;
using TravelRouteApi.Business.Impl.Graph;
using TravelRouteApi.Dto;
using TravelRouteApi.Exceptions;
using TravelRouteApi.Repository.Impl;

namespace TravelRouteApi.Business.Impl
{
    public class DijkstraLowestPriceFinder : ILowestPriceFinder
    {
        private readonly IRouteRepository routeRepository;
        private readonly IGraphCreator graphCreator;
        private readonly IDijkstraImplementation dijkstraImplementation;

        public DijkstraLowestPriceFinder(IRouteRepository routeRepository, IGraphCreator graphCreator, IDijkstraImplementation dijkstraImplementation)
        {
            this.routeRepository = routeRepository;
            this.graphCreator = graphCreator;
            this.dijkstraImplementation = dijkstraImplementation;
        }
        public BestRoute Find(Route route)
        {
            var routes = routeRepository.GetAll();

            List<Node> nodes = graphCreator.CreateNodes(routes);

            var nodeFrom = nodes.FirstOrDefault(node => node.Label == route.From);
            var nodeTo = nodes.FirstOrDefault(node => node.Label == route.To);

            if (nodeFrom == null)
                throw new DestinyException(route.From);

            if (nodeTo == null)
                throw new DestinyException(route.To);

            return dijkstraImplementation.FindBestRoute(nodeFrom, nodeTo);
        }
    }
}
