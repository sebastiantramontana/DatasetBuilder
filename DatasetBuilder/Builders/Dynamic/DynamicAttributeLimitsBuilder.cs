using DatasetBuilder.Orderings;

namespace DatasetBuilder.Builders.Dynamic
{
    public class DynamicAttributeLimitsBuilder : AttributeLimitsBuilderBase<string, string, string>
    {
        internal DynamicAttributeLimitsBuilder(string labelValue, LabelBuilderBase<string,string,string> labelBuilder, IOrdering defaultOrdering)
             : base(labelValue, labelBuilder, defaultOrdering)
        {
        }

        private protected override string MapAttribute(string attribute)
        {
            return attribute;
        }
    }
}
