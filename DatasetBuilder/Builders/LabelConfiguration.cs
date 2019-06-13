using System.Collections.Generic;

namespace DatasetBuilder.Builders
{
    internal class LabelConfiguration<TLabel, TAttributeKind> : ILabelConfiguration<TLabel, TAttributeKind>
    {
        internal LabelConfiguration(TLabel labelValue, IEnumerable<IAttributeLimits<TAttributeKind>> attributesLimits)
        {
            this.LabelValue = labelValue;
            this.AttributesLimits = attributesLimits;
        }

        public TLabel LabelValue { get; }
        public IEnumerable<IAttributeLimits<TAttributeKind>> AttributesLimits { get; }
    }
}
