namespace TravelRouteApi.Business.Impl.Graph
{
    public class NeighborhoodInfo
    {
        public Node Node { get; }
        public int WeightToNode { get; }

        public NeighborhoodInfo(Node node, int weightToNode)
        {
            Node = node;
            WeightToNode = weightToNode;
        }
    }
}
