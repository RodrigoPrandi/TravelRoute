using System;

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
            
        }
    }
}