using System;
using System.Collections.Generic;
using System.Text;

namespace DatasetBuilder.AttributeNumberGenerators
{
    public class AttributeValues<TAttributeKind>
    {
        internal AttributeValues(TAttributeKind attribute, IEnumerable<double> values)
        {
            this.Attribute = attribute;
            this.Values = values;
        }

        public TAttributeKind Attribute { get; }
        public IEnumerable<double> Values { get; }
    }
}
