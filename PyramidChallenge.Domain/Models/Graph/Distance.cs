namespace PyramidChallenge.Domain.Models.Graphs
{
    public struct Distance
    {
		public int Value { get; }

		private Distance(int value)
		{
			Value = value;
		}

		public static Distance Create(int value)
		{
			return new Distance(value);
		}

		public override string ToString() => Value.ToString();
	}
}
