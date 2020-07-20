using TravelRouteApi.Business.Impl.Graph;

namespace TravelRouteApi.Business.Impl
{
    public class Weight
    {
        public Node From { get; }
        public int Value { get; }

        public Weight(Node @from, int value)
        {
            From = @from;
            Value = value;
        }
    }
}
