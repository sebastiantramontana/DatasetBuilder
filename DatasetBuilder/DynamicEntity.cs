using System;
using System.Collections.Generic;
using System.Text;

namespace DatasetBuilder
{
    public class DynamicEntity
    {
        internal DynamicEntity(string label, double[] values)
        {
            this.Label = label;
            this.Values = values;
        }

        public string Label { get; }
        public double[] Values { get; }
    }
}
