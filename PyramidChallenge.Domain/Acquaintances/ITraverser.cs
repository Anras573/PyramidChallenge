using PyramidChallenge.Domain.Models.Graphs;
using PyramidChallenge.Domain.Models.Node;

namespace PyramidChallenge.Domain.Acquaintances
{
    public interface ITraverser
    {
        PyramidTraverserResult Traverse(BinaryNode root);
    }
}
