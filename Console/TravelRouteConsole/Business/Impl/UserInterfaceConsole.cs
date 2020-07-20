using System;
using TravelRouteConsole.Dto;
using TravelRouteConsole.Factory;

namespace TravelRouteConsole.Business.Impl
{
    class UserInterfaceConsole : IUserInterface
    {
        private readonly IRouteFactory routeFactory;

        public UserInterfaceConsole(IRouteFactory routeFactory)
        {
            this.routeFactory = routeFactory;
        }
        public Route GetRoute()
        {
            Console.Write("Please enter the route: ");
            var stringRoute = Console.ReadLine();
            return routeFactory.Create(stringRoute);
        }

        public void PrintBestRoute(BestRoute bestRoute)
        {
            Console.WriteLine($"best route: {bestRoute.Route} > ${bestRoute.Value}");
        }

        public void PrintException(Exception exception)
        {
            Console.WriteLine($"ERRO: {exception.Message}");
        }
    }
}
