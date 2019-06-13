using DatasetBuilder.Orderings;

namespace DatasetBuilder.Builders
{
    internal class AttributeLimits<TAttributeKind> : IAttributeLimits<TAttributeKind>
    {
        internal AttributeLimits(TAttributeKind attribute, Limits limits, IOrdering ordering)
        {
            this.Attribute = attribute;
            this.Limits = limits;
            this.Ordering = ordering;
        }

        public TAttributeKind Attribute { get; }
        public Limits Limits { get; }
        public IOrdering Ordering { get; }

        public override string ToString()
        {
            return $"{this.Attribute}: {this.Limits}";
        }
    }
}
