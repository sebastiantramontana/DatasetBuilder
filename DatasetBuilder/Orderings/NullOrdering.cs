using System.Collections.Generic;

namespace DatasetBuilder.Orderings
{
    internal class NullOrdering : OrderingBase
    {
        private NullOrdering() : base("Null")
        {
        }

        public override IEnumerable<double> Order(IEnumerable<double> values)
        {
            return new double[] { };
        }

        internal static NullOrdering Instance { get; } = new NullOrdering();
    }
}
