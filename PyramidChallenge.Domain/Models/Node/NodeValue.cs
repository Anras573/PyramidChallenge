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

		public bool IsEven { get; }
		public bool IsOdd => !IsEven;

		public override string ToString() => Value.ToString();
	}
}
