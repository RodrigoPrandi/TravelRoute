using System;
using TravelRouteConsole.Business;
using TravelRouteConsole.IoC;

namespace TravelRouteConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
                throw new ArgumentException("Please enter a csv file.");
            if (args.Length != 1)
                throw new ArgumentException("Only one argument should be informed.");

            var file = args[0];

            var travelRouteController = RegisterIoC.Get<ITravelRouteController>();

            travelRouteController.Initialize(file);
        }
    }
}