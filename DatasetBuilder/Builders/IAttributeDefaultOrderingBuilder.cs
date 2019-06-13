using DatasetBuilder.Orderings;

namespace DatasetBuilder.Builders
{
    public interface IAttributeDefaultOrderingBuilder<TLabel, TAttributeArg, TAttributeKind>
    {
        IAttributeDefaultOrderingBuilder<TLabel, TAttributeArg, TAttributeKind> Attribute(TAttributeArg attribute, IOrdering defaultOrdering);
        IAttributeLimitsBuilder<TAttributeArg, TLabel> Label(TLabel value);
    }
}