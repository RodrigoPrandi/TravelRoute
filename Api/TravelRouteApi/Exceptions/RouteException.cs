using System;

namespace TravelRouteApi.Exceptions
{
    public class RouteException : BusinessException
    {
        public RouteException(string from, string to) : base($"Route cannot be found between {from} and {to}!")
        {
        }
    }
}
