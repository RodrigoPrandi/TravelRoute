using TravelRouteConsole.Dto;

namespace TravelRouteConsole.Factory
{
    public interface IRouteFactory
    {
        Route Create(string stringRoute);
    }
}
