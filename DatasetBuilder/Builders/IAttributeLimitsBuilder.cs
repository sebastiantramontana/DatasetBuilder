using DatasetBuilder.Orderings;

namespace DatasetBuilder.Builders
{
    public interface IAttributeLimitsBuilder<TAttributeArg, TLabel>
    {
        IAttributeLimitsBuilder<TAttributeArg, TLabel> Attribute(TAttributeArg attribute, double min, double max);
        IAttributeLimitsBuilder<TAttributeArg, TLabel> Attribute(TAttributeArg attribute, double min, double max, IOrdering ordering);
        IAttributeLimitsBuilder<TAttributeArg, TLabel> Label(TLabel value);
    }
}