using System.Collections.Generic;
using System.Linq;

namespace DatasetBuilder.Orderings
{
    internal class MaxToCenterOrdering : ToCenterOrderingBase
    {
        private MaxToCenterOrdering() : base("Max to Center")
        {
        }

        protected override IEnumerable<double> OrderValues(IEnumerable<double> values) => values.OrderByDescending(v => v);

        internal static MaxToCenterOrdering Instance { get; } = new MaxToCenterOrdering();
    }
}
