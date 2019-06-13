using System.Collections.Generic;

namespace DatasetBuilder.Builders
{
    internal interface ILabelConfiguration<TLabel, TAttributeKind>
    {
        TLabel LabelValue { get; }
        IEnumerable<IAttributeLimits<TAttributeKind>> AttributesLimits { get; }
    }
}
