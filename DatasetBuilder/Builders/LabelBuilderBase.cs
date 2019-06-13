using DatasetBuilder.Orderings;
using System.Collections.Generic;
using System.Linq;

namespace DatasetBuilder.Builders
{
    public abstract class LabelBuilderBase<TLabel, TAttributeArg, TAttributeKind> : ILabelBuilder<TLabel, TAttributeArg, TAttributeKind>
    {
        private readonly ICollection<AttributeLimitsBuilderBase<TAttributeArg, TAttributeKind, TLabel>> _labelValues;
        private readonly AttributeDefaultOrderingBuilderBase<TLabel, TAttributeArg, TAttributeKind> _attributedefaultOrdering;
        private readonly IOrdering _defaultOrdering;

        private protected LabelBuilderBase(IOrdering defaultOrdering)
        {
            _labelValues = new List<AttributeLimitsBuilderBase<TAttributeArg, TAttributeKind, TLabel>>();
            _attributedefaultOrdering = CreateAttributeDefaultOrderingBuilder(this);
            _defaultOrdering = defaultOrdering;
        }

        public IAttributeLimitsBuilder<TAttributeArg, TLabel> Label(TLabel value)
        {
            var attrLimitsBuilder = CreateAttributeLimitsBuilder(value, this, _defaultOrdering);

            _labelValues.Add(attrLimitsBuilder);
            return attrLimitsBuilder;
        }

        public IAttributeDefaultOrderingBuilder<TLabel, TAttributeArg, TAttributeKind> Ordering()
        {
            return _attributedefaultOrdering;
        }

        internal IOrdering GetAttributeDefaultOrdering(TAttributeKind attribute)
        {
            return _attributedefaultOrdering.GetAttributeDefaultOrderings().SingleOrDefault(attr => attr.Attribute.Equals(attribute))?.DefaultOrdering;
        }

        internal IEnumerable<ILabelConfiguration<TLabel, TAttributeKind>> GetLabels()
        {
            var labels = _labelValues.Select(lab => lab.GetLabelConfiguration());
            return labels;
        }

        private protected abstract AttributeDefaultOrderingBuilderBase<TLabel, TAttributeArg, TAttributeKind> CreateAttributeDefaultOrderingBuilder(LabelBuilderBase<TLabel, TAttributeArg, TAttributeKind> labelBuilder);
        private protected abstract AttributeLimitsBuilderBase<TAttributeArg, TAttributeKind, TLabel> CreateAttributeLimitsBuilder(TLabel labelValue, LabelBuilderBase<TLabel, TAttributeArg, TAttributeKind> labelBuilder, IOrdering defaultOrdering);
    }
}
