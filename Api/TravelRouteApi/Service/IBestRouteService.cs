using TravelRouteApi.Dto;

namespace TravelRouteApi.Service
{
    public interface IBestRouteService
    {
        BestRoute CalcBestRoute(Route route);
    }
}
