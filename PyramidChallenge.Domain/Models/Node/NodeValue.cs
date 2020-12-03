namespace PyramidChallenge.Domain.Models.Node
{
    public struct NodeValue
    {
        public int Value { get; }

        private NodeValue(int value)
        {
	        IsEven = value % 2 == 0;
	        Value = value;
        }

        public static NodeValue Create(int value) => new NodeValue(value);
        public static NodeValue Parse(string value) => new NodeValue(int.Parse(value));

        public bool IsEven { get; }
        public bool IsOdd => !IsEven;

        public override string ToString() => Value.ToString();

        public bool Equals(NodeValue other) => Value == other.Value;

        public override bool Equals(object obj)
        {
            return obj is NodeValue value && Equals(value);
        }

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(NodeValue left, NodeValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NodeValue left, NodeValue right)
        {
            return !(left == right);
        }
    }
}
