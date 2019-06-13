using System.Collections.Generic;

namespace DatasetBuilder.Orderings
{
    internal class NoOrdering : OrderingBase
    {
        private NoOrdering() : base("None")
        {
        }

        public override IEnumerable<double> Order(IEnumerable<double> values)
        {
            return values;
        }

        internal static NoOrdering Instance { get; } = new NoOrdering();
    }
}
