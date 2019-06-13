using DatasetBuilder.Orderings;
using System.Collections.Generic;

namespace DatasetBuilder.Builders
{
    public abstract class AttributeDefaultOrderingBuilderBase<TLabel, TAttributeArg, TAttributeKind> : IAttributeDefaultOrderingBuilder<TLabel, TAttributeArg, TAttributeKind>
    {
        private readonly ICollection<AttributeDefaultOrdering<TAttributeKind>> _attributesDefaultOrderings;
        private readonly ILabelBuilder<TLabel, TAttributeArg, TAttributeKind> _labelBuilder;

        internal AttributeDefaultOrderingBuilderBase(ILabelBuilder<TLabel, TAttributeArg, TAttributeKind> labelBuilder)
        {
            _attributesDefaultOrderings = new List<AttributeDefaultOrdering<TAttributeKind>>();
            _labelBuilder = labelBuilder;
        }

        public IAttributeLimitsBuilder<TAttributeArg, TLabel> Label(TLabel value)
        {
            return _labelBuilder.Label(value);
        }

        public IAttributeDefaultOrderingBuilder<TLabel, TAttributeArg, TAttributeKind> Attribute(TAttributeArg attribute, IOrdering defaultOrdering)
        {
            if (!OrderingBase.IsNull(defaultOrdering))
            {
                var attr = MapAttribute(attribute);
                _attributesDefaultOrderings.Add(new AttributeDefaultOrdering<TAttributeKind>(attr, defaultOrdering));
            }

            return this;
        }

        internal IEnumerable<AttributeDefaultOrdering<TAttributeKind>> GetAttributeDefaultOrderings()
        {
            return _attributesDefaultOrderings;
        }

        private protected abstract TAttributeKind MapAttribute(TAttributeArg attribute);
    }
}
