using System;
using System.Collections.Generic;
using System.Linq;

namespace DatasetBuilder.Orderings
{
    internal class AscOrdering : OrderingBase
    {
        private AscOrdering() : base("Ascending")
        {
        }

        public override IEnumerable<double> Order(IEnumerable<double> values)
        {
            return values.OrderBy(v => v);
        }

        internal static AscOrdering Instance { get; } = new AscOrdering();
    }
}
