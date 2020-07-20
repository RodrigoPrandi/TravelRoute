using TravelRouteApi.Business.Impl.Graph;
using TravelRouteApi.Dto;

namespace TravelRouteApi.Business.Impl
{
    public interface IDijkstraImplementation
    {
        BestRoute FindBestRoute(Node nodeFrom, Node nodeTo);
    }
}
