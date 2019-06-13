namespace DatasetBuilder.Builders.Dynamic
{
    public class DynamicAttributeDefaultOrderingBuilder : AttributeDefaultOrderingBuilderBase<string, string, string>
    {
        internal DynamicAttributeDefaultOrderingBuilder(LabelBuilderBase<string, string, string> labelBuilder)
            : base(labelBuilder)
        {
        }

        private protected override string MapAttribute(string attribute)
        {
            return attribute;
        }
    }
}
