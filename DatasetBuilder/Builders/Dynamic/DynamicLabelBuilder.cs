using DatasetBuilder.Orderings;
using System.Collections.Generic;
using System.Linq;

namespace DatasetBuilder.Builders.Dynamic
{
    public class DynamicLabelBuilder : LabelBuilderBase<string, string, string>
    {
        public DynamicLabelBuilder(IOrdering defaultOrdering)
            :base(defaultOrdering)
        {
        }

        private protected override AttributeDefaultOrderingBuilderBase<string, string, string> CreateAttributeDefaultOrderingBuilder(LabelBuilderBase<string, string, string> labelBuilder)
        {
            return new DynamicAttributeDefaultOrderingBuilder(labelBuilder);
        }

        private protected override AttributeLimitsBuilderBase<string, string, string> CreateAttributeLimitsBuilder(string labelValue, LabelBuilderBase<string, string, string> labelBuilder, IOrdering defaultOrdering)
        {
            return new DynamicAttributeLimitsBuilder(labelValue, labelBuilder, defaultOrdering);
        }
    }
}
