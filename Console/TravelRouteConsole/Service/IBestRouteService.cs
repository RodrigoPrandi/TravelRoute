using TravelRouteConsole.Dto;

namespace TravelRouteConsole.Service
{
    public interface IBestRouteService
    {
        BestRoute CalcBestRoute(Route route);
    }
}
