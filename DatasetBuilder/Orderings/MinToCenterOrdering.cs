using System.Collections.Generic;
using System.Linq;

namespace DatasetBuilder.Orderings
{
    internal class MinToCenterOrdering : ToCenterOrderingBase
    {
        private MinToCenterOrdering() : base("Min to Center")
        {
        }

        protected override IEnumerable<double> OrderValues(IEnumerable<double> values) => values.OrderBy(v => v);

        internal static MinToCenterOrdering Instance { get; } = new MinToCenterOrdering();
    }
}
