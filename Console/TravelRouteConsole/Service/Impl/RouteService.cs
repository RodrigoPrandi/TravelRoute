using System.Collections.Generic;
using TravelRouteConsole.Business;
using TravelRouteConsole.Dto;

namespace TravelRouteConsole.Service.Impl
{
    class RouteService : IRouteService
    {
        private readonly ITravelRouteApi travelRouteApi;

        public RouteService(ITravelRouteApi travelRouteApi)
        {
            this.travelRouteApi = travelRouteApi;
        }
        public void Create(IEnumerable<RouteValue> routesValue)
        {
            foreach (var routeValue in routesValue)
            {
                Create(routeValue);
            }
        }

        public void Create(RouteValue routeValue)
        {
            travelRouteApi.PostSync<RouteValue>("api/route", routeValue);
        }
    }
}