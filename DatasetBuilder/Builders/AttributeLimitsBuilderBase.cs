using DatasetBuilder.Orderings;
using System.Collections.Generic;

namespace DatasetBuilder.Builders
{
    public abstract class AttributeLimitsBuilderBase<TAttributeArg, TAttributeKind, TLabel> : IAttributeLimitsBuilder<TAttributeArg, TLabel>
    {
        private readonly TLabel _labelValue;
        private readonly LabelBuilderBase<TLabel, TAttributeArg, TAttributeKind> _labelBuilder;
        private readonly IOrdering _defaultOrdering;
        private readonly ICollection<IAttributeLimits<TAttributeKind>> _attributesLimits;

        private protected AttributeLimitsBuilderBase(TLabel labelValue, LabelBuilderBase<TLabel, TAttributeArg, TAttributeKind> labelBuilder, IOrdering defaultOrdering)
        {
            _labelValue = labelValue;
            _labelBuilder = labelBuilder;
            _defaultOrdering = defaultOrdering;
            _attributesLimits = new List<IAttributeLimits<TAttributeKind>>();
        }

        public IAttributeLimitsBuilder<TAttributeArg, TLabel> Label(TLabel value)
        {
            return _labelBuilder.Label(value);
        }

        public IAttributeLimitsBuilder<TAttributeArg, TLabel> Attribute(TAttributeArg attribute, double min, double max)
        {
            var attr = MapAttribute(attribute);
            var defaultOrdering = GetAttributeDefaultOrdering(attr);

            return AddAttributeProperty(attr, min, max, defaultOrdering);
        }

        public IAttributeLimitsBuilder<TAttributeArg, TLabel> Attribute(TAttributeArg attribute, double min, double max, IOrdering ordering)
        {
            var attr = MapAttribute(attribute);
            var finalOrdering = OrderingBase.Coalesce(ordering, GetAttributeDefaultOrdering(attr));

            return AddAttributeProperty(attr, min, max, finalOrdering);
        }

        internal ILabelConfiguration<TLabel, TAttributeKind> GetLabelConfiguration()
        {
            return new LabelConfiguration<TLabel, TAttributeKind>(_labelValue, _attributesLimits);
        }

        protected IAttributeLimitsBuilder<TAttributeArg, TLabel> AddAttributeProperty(TAttributeKind attribute, double min, double max, IOrdering ordering)
        {
            _attributesLimits.Add(new AttributeLimits<TAttributeKind>(attribute, new Limits(min, max), ordering));
            return this;
        }

        protected IOrdering GetAttributeDefaultOrdering(TAttributeKind attr)
        {
            var attrDefaultOrdering = _labelBuilder.GetAttributeDefaultOrdering(attr);
            return OrderingBase.Coalesce(attrDefaultOrdering, _defaultOrdering);
        }

        private protected abstract TAttributeKind MapAttribute(TAttributeArg attribute);
    }
}
