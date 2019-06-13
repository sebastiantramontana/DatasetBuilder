using System;
using System.Collections.Generic;
using System.Text;

namespace DatasetBuilder.Orderings
{
    public static class OrderingFactory
    {
        public static IOrdering Null { get; } = NullOrdering.Instance;
        public static IOrdering None { get; } = NoOrdering.Instance;
        public static IOrdering Ascending { get; } = AscOrdering.Instance;
        public static IOrdering Descending { get; } = DescOrdering.Instance;
        public static IOrdering MaxToCenter { get; } = MaxToCenterOrdering.Instance;
        public static IOrdering MinToCenter { get; } = MinToCenterOrdering.Instance;
        public static IOrdering Random { get; } = RandomOrdering.Instance;

        public static IOrdering[] All { get; } = new[]
        {
            Null,
            None,
            Ascending,
            Descending,
            MaxToCenter,
            MinToCenter,
            Random
        };
    }
}
