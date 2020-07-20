using System.Collections.Generic;
using TravelRouteApi.Dto;

namespace TravelRouteApi.Repository.Impl
{
    public interface IRouteRepository
    {
        bool Exists(RouteValue routeValue);

        void Save(RouteValue routeValue);

        List<RouteValue> GetAll();
    }
}
