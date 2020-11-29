using System.Collections.Generic;
using System.Linq;

namespace PyramidChallenge.Domain.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<(int, TValue)> AsIndexable<TValue>(this IEnumerable<TValue> iterator)
        {
            return iterator.Select((value, i) => (i, value));
        }
    }
}
