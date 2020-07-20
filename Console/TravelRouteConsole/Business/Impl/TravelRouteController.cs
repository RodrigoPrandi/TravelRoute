using System;
using TravelRouteConsole.Service;

namespace TravelRouteConsole.Business
{
    class TravelRouteController : ITravelRouteController
    {
        private readonly IUserInterface userInterface;
        private readonly IRouteReader routeReader;
        private readonly IRouteService routeService;
        private readonly IBestRouteService bestRouteService;

        public TravelRouteController(IUserInterface userInterface, IRouteReader routeReader, IRouteService routeService, IBestRouteService bestRouteService)
        {
            this.userInterface = userInterface;
            this.routeReader = routeReader;
            this.routeService = routeService;
            this.bestRouteService = bestRouteService;
        }

        public void Initialize(string file)
        {
            var initialRouteList = routeReader.ReadFile(file);
            routeService.Create(initialRouteList);

            while (true)
            {
                try
                {
                    var route = userInterface.GetRoute();

                    var bestRoute = bestRouteService.CalcBestRoute(route);

                    userInterface.PrintBestRoute(bestRoute);
                }
                catch (Exception exception)
                {
                    userInterface.PrintException(exception);
                }
            }
        }
    }
}
