using System;
using System.Collections.Generic;
using System.Linq;

namespace DatasetBuilder.Orderings
{
    internal class DescOrdering : OrderingBase
    {
        private DescOrdering() : base("Descending")
        {
        }

        public override IEnumerable<double> Order(IEnumerable<double> values)
        {
            return values.OrderByDescending(v => v);
        }

        internal static DescOrdering Instance { get; } = new DescOrdering();
    }
}
