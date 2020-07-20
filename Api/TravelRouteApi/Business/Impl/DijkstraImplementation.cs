using System;
using System.Linq;
using TravelRouteApi.Business.Impl.Graph;
using TravelRouteApi.Dto;
using TravelRouteApi.Exceptions;

namespace TravelRouteApi.Business.Impl
{
    public class DijkstraImplementation : IDijkstraImplementation
    {
        public BestRoute FindBestRoute(Node nodeFrom, Node nodeTo)
        {
            var control = new ControlData();

            control.UpdateWeight(nodeFrom, new Weight(null, 0));
            control.ScheduleVisitTo(nodeFrom);

            while (control.HasScheduledVisits)
            {
                var visitingNode = control.GetNodeToVisit();
                var visitingNodeWeight = control.QueryWeight(visitingNode);
                control.RegisterVisitTo(visitingNode);

                foreach (var neighborhoodInfo in visitingNode.Neighbors)
                {
                    if (!control.WasVisited(neighborhoodInfo.Node))
                        control.ScheduleVisitTo(neighborhoodInfo.Node);

                    var neighborWeight = control.QueryWeight(neighborhoodInfo.Node);

                    var probableWeight = (visitingNodeWeight.Value + neighborhoodInfo.WeightToNode);

                    if (neighborWeight.Value > probableWeight)
                        control.UpdateWeight(neighborhoodInfo.Node, new Weight(visitingNode, probableWeight));
                }
            }

            if (!control.HasComputedPathToOrigin(nodeTo))
                throw new RouteException(nodeFrom.Label, nodeTo.Label);

            return new BestRoute
            {
                Route = string.Join(" - ", control.ComputedPathToOrigin(nodeTo).Reverse().Select(x => x.Label)),
                Value = control.QueryWeight(nodeTo).Value
            };
        }
    }
}
