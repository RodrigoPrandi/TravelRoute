using System;

namespace TravelRouteApi.Exceptions
{
    public class DestinyException : BusinessException
    {
        public DestinyException(string destination) : base($"{destination}: Destination not registered!")
        {
        }
    }
}
