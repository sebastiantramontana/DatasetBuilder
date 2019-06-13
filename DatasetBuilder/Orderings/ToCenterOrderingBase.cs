using System.Collections.Generic;
using System.Linq;

namespace DatasetBuilder.Orderings
{
    public abstract class ToCenterOrderingBase : OrderingBase
    {
        private protected ToCenterOrderingBase(string name) : base(name)
        {

        }

        public override IEnumerable<double> Order(IEnumerable<double> values)
        {
            var arrValues = OrderValues(values).ToArray();
            int length = arrValues.Length;
            int newIndex = length / 2 - ((length % 2 == 0) ? 1 : 0);
            bool toRight = true;

            var orderedValues = new double[length];

            for (int i = 0; i < length; i++)
            {
                orderedValues[newIndex] = arrValues[i];

                var next = i + 1;
                newIndex += toRight ? next : -next;
                toRight = !toRight;
            }

            return orderedValues;
        }

        protected abstract IEnumerable<double> OrderValues(IEnumerable<double> values);
    }
}
