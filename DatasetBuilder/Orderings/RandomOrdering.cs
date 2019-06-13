using System;
using System.Collections.Generic;
using System.Linq;

namespace DatasetBuilder.Orderings
{
    internal class RandomOrdering : OrderingBase
    {
        private int _seed = 1;
        private int _prev = 1;

        private RandomOrdering() : base("Random")
        {

        }

        public override IEnumerable<double> Order(IEnumerable<double> values)
        {
            Random rnd = new Random(_seed);
            var tmp = _seed;
            _seed += _prev;
            _prev = tmp;

            var arrValues = values.ToArray();

            for (int i = 0; i < arrValues.Length; ++i)
            {
                int randomIndex = rnd.Next(arrValues.Length);
                var temp = arrValues[randomIndex];
                arrValues[randomIndex] = arrValues[i];
                arrValues[i] = temp;
            }

            return arrValues;
        }

        internal static RandomOrdering Instance { get; } = new RandomOrdering();
    }
}
