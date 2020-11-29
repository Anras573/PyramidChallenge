using PyramidChallenge.Domain.Acquaintances;
using PyramidChallenge.Domain.Models.Graphs;
using PyramidChallenge.Domain.Models.Node;
using System.Collections.Generic;

namespace PyramidChallenge.Domain.Graphs
{
    public class PyramidTraverser : ITraverser
    {
        public PyramidTraverserResult Traverse(BinaryNode root)
        {
            var path = new List<NodeValue>();
            var distance = Distance.Create(0);

            (distance, path) = Traverse(root, distance, path);

            return new PyramidTraverserResult(distance, path);
        }

        private (Distance, List<NodeValue>) Traverse(BinaryNode root, Distance distance, List<NodeValue> path)
        {
            distance = Distance.Create(distance.Value + root.Value.Value);
            path.Add(root.Value);

            if (root.Left == null && root.Right == null)
                return (distance, path);

            var leftPath = new List<NodeValue>(path);
            var leftDistance = distance;
            var rightPath = new List<NodeValue>(path);
            var rightDistance = distance;

            if (CanTraverse(root, root.Left))
                (leftDistance, leftPath) = Traverse(root.Left, leftDistance, leftPath);

            if (CanTraverse(root, root.Right))
                (rightDistance, rightPath) = Traverse(root.Right, rightDistance, rightPath);

            return CalculateResult(
                leftDistance: leftDistance,
                leftPath: leftPath,
                rightDistance: rightDistance,
                rightPath: rightPath);
        }

        private bool CanTraverse(BinaryNode root, BinaryNode child)
        {
            return root.Value.IsEven
                ? child.Value.IsOdd
                : child.Value.IsEven;
        }

        private (Distance, List<NodeValue>) CalculateResult(
            Distance leftDistance,
            List<NodeValue> leftPath,
            Distance rightDistance,
            List<NodeValue> rightPath)
        {
            if (leftPath.Count == rightPath.Count)
            {
                return leftDistance.Value > rightDistance.Value
                    ? (leftDistance, leftPath)
                    : (rightDistance, rightPath);
            }

            return leftPath.Count > rightPath.Count
                    ? (leftDistance, leftPath)
                    : (rightDistance, rightPath);
        }
    }
}
