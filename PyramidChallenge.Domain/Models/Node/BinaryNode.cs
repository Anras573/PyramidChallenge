namespace PyramidChallenge.Domain.Models.Node
{
    public class BinaryNode
    {
        public BinaryNode Left { get; set; }
        public BinaryNode Right { get; set; }

        public NodeValue Value { get; }

        public BinaryNode(int value)
        {
            Value = NodeValue.Create(value);
        }
    }
}
