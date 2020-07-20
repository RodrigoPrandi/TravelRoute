using TravelRouteApi.Dto;
using TravelRouteApi.Repository.Impl;

namespace TravelRouteApi.Service.Impl
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository routeRepository;

        public RouteService(IRouteRepository routeRepository)
        {
            this.routeRepository = routeRepository;
        }

        public void Save(RouteValue routeValue)
        {
            routeRepository.Save(routeValue);
        }
    }
}
