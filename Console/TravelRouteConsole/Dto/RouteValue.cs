namespace TravelRouteConsole.Dto
{
    public class RouteValue : Route
    {
        public int Value { get; }

        public RouteValue(string from, string to, int value) : base(from, to)
        {
            Value = value;
        }
    }
}
