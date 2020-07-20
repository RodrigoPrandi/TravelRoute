using System.Web;
using TravelRouteConsole.Business;
using TravelRouteConsole.Dto;

namespace TravelRouteConsole.Service.Impl
{
    class BestRouteService : IBestRouteService
    {
        private readonly ITravelRouteApi travelRouteApi;

        public BestRouteService(ITravelRouteApi travelRouteApi)
        {
            this.travelRouteApi = travelRouteApi;
        }
        public BestRoute CalcBestRoute(Route route)
        {
            var queryparamter = HttpUtility.ParseQueryString(string.Empty);
            queryparamter.Add("to", route.To);
            queryparamter.Add("from", route.From);

            var path = $"api/bestroute?{queryparamter.ToString()}";

            return travelRouteApi.GetSync<BestRoute>(path);
        }
    }
}
