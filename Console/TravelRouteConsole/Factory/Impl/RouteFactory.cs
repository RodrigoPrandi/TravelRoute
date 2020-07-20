using System;
using System.Text.RegularExpressions;
using TravelRouteConsole.Dto;

namespace TravelRouteConsole.Factory.Impl
{
    class RouteFactory : IRouteFactory
    {
        public Route Create(string route)
        {
            var pattern = @"^(?<from>[A-Z]{3})-(?<to>[A-Z]{3})$";

            Regex r = new Regex(pattern);
            Match m = r.Match(route);

            if (m.Success)
                return new Route(m.Groups["from"].Value, m.Groups["to"].Value);
            throw new Exception("Invalid route format! The format valid is \"XXX-XXX\".");
        }
    }
}
