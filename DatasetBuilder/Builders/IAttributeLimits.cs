using DatasetBuilder.Orderings;

namespace DatasetBuilder.Builders
{
    public interface IAttributeLimits<TAttributeKind>
    {
        TAttributeKind Attribute { get; }
        Limits Limits { get; }
        IOrdering Ordering { get; }
    }
}
