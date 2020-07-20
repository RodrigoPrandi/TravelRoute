namespace TravelRouteConsole.Dto
{
    public class Route
    {
        public string From { get; }
        public string To { get; }

        public Route(string from, string to)
        {
            From = from;
            To = to;
        }
    }
}
