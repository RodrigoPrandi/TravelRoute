using System;
using TravelRouteConsole.Dto;

namespace TravelRouteConsole.Business
{
    public interface IUserInterface
    {
        Route GetRoute();
        void PrintBestRoute(BestRoute bestRoute);
        void PrintException(Exception exception);
    }
}
