using System.Collections.Generic;
using TravelRouteApi.Business.Impl.Graph;
using TravelRouteApi.Dto;

namespace TravelRouteApi.Business.Impl
{
    public interface IGraphCreator
    {
        List<Node> CreateNodes(List<RouteValue> routes);
    }
}
