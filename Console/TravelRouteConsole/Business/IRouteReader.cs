using System.Collections.Generic;
using TravelRouteConsole.Dto;

namespace TravelRouteConsole.Business
{
    public interface IRouteReader
    {
        List<RouteValue> ReadFile(string file);
    }
}
