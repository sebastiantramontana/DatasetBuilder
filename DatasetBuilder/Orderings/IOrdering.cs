using System.Collections.Generic;

namespace DatasetBuilder.Orderings
{
    public interface IOrdering
    {
        IEnumerable<double> Order(IEnumerable<double> values);
    }
}
