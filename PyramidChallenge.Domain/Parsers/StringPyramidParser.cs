using PyramidChallenge.Domain.Acquaintances;
using PyramidChallenge.Domain.Extensions;
using PyramidChallenge.Domain.Models.Node;
using System.Collections.Generic;
using System.Linq;

namespace PyramidChallenge.Domain.Parsers
{
    public class StringPyramidParser : IParser<IEnumerable<string>, BinaryNode>
    {
        public BinaryNode Parse(IEnumerable<string> input)
        {
            BinaryNode root = new BinaryNode(input.First());
            List<BinaryNode> previousRow = new List<BinaryNode> { root };
            
            foreach (var line in input.Skip(1))
            {
                var currentRow = new List<BinaryNode>();
                var splittedLine = line.Trim().Split(" ");

                foreach (var (i, item) in splittedLine.AsIndexable())
                {
                    var node = new BinaryNode(item);
                    currentRow.Add(node);

                    if (IsParentAvailable(previousRow, i))
                        previousRow[i].Left = node;

                    if (IsParentsLeftNeighbourAvailable(previousRow, i))
                        previousRow[i - 1].Right = node;
                }

                previousRow = currentRow;
            }

            return root;
        }

        private bool IsParentAvailable(List<BinaryNode> previousRow, int i)
        {
            return i < previousRow.Count
                && previousRow[i].Left == null;
        }

        private bool IsParentsLeftNeighbourAvailable(List<BinaryNode> previousRow, int i)
        {
            return i > 0
                && i <= previousRow.Count
                && previousRow[i - 1].Right == null;
        }
    }
}
