using System;
using System.Linq;
using TravelRouteApi.Business.Impl.Graph;
using TravelRouteApi.Dto;
using TravelRouteApi.Exceptions;

namespace TravelRouteApi.Business.Impl
{
    public class DijkstraImplementation : IDijkstraImplementation
    {
        public BestRoute FindBestRoute(Node nodeFrom, Node nodeTo)
        {
            return new BestRoute();
        }
    }
}
