using TravelRouteApi.Business;
using TravelRouteApi.Dto;

namespace TravelRouteApi.Service.Impl
{
    public class BestRouteService : IBestRouteService
    {
        private readonly IFindFactory findFactory;

        public BestRouteService(IFindFactory findFactory)
        {
            this.findFactory = findFactory;
        }

        public BestRoute CalcBestRoute(Route route)
        {
            var bestRouteFinder =  findFactory.GetFinder(FindBestBy.VALUE);

            return bestRouteFinder.Find(route);
        }
    }
}
