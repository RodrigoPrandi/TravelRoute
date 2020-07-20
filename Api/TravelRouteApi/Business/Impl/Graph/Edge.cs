using System;

namespace TravelRouteApi.Business.Impl.Graph
{
    public class Edge
    {
        public int Value { get; }
        public Node Node1 { get; }
        public Node Node2 { get; }

        private Edge(int value, Node node1, Node node2)
        {
            if (value <= 0)
                throw new ArgumentException("Edge value needs to be positive.");

            Value = value;
            Node1 = node1;
            node1.Assign(this);
            Node2 = node2;
            node2.Assign(this);
        }

        public static Edge Create(int value, Node node1, Node node2)
        {
            return new Edge(value, node1, node2);
        }
    }
}
