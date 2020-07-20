using System.Collections.Generic;
using System.Linq;

namespace TravelRouteApi.Business.Impl.Graph
{
    public class Node
    {
        public string Label { get; }
        public Node(string label)
        {
            Label = label;
        }

        readonly List<Edge> _edges = new List<Edge>();
        public IEnumerable<Edge> Edges => _edges;

        public IEnumerable<NeighborhoodInfo> Neighbors =>
            from edge in Edges
            select new NeighborhoodInfo(
                edge.Node1 == this ? edge.Node2 : edge.Node1,
                edge.Value
                );

        public void Assign(Edge edge)
        {
            _edges.Add(edge);
        }

        public void ConnectTo(Node other, int connectionValue)
        {
            Edge.Create(connectionValue, this, other);
        }

    }
}
