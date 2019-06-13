using DatasetBuilder.Orderings;

namespace DatasetBuilder.Builders
{
    internal class AttributeDefaultOrdering<TAttributeKind>
    {
        internal AttributeDefaultOrdering(TAttributeKind attribute, IOrdering defaultOrdering)
        {
            this.Attribute = attribute;
            this.DefaultOrdering = defaultOrdering;
        }

        internal TAttributeKind Attribute { get; }
        internal IOrdering DefaultOrdering { get; }
    }
}
