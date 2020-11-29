using PyramidChallenge.Domain.Acquaintances;
using PyramidChallenge.Domain.Models.Node;
using System.Collections.Generic;

namespace PyramidChallenge.Domain.Models.Graphs
{
    public class PyramidTraverserResult
    {
        public Distance Distance { get; }

        public IReadOnlyList<NodeValue> Route { get; }

        public PyramidTraverserResult(Distance distance, IReadOnlyList<NodeValue> route)
        {
            Distance = distance;
            Route = route;
        }
    }
}
