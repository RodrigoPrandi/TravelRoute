using System.Collections.Generic;
using TravelRouteConsole.Dto;

namespace TravelRouteConsole.Service
{
    public interface IRouteService
    {
        void Create(IEnumerable<RouteValue> routesValue);
    }
}
