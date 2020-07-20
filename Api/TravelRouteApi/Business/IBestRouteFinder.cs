using TravelRouteApi.Dto;

namespace TravelRouteApi.Business
{
    public interface IBestRouteFinder
    {
        BestRoute Find(Route route);
    }
}
