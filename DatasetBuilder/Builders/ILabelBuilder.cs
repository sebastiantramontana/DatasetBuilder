namespace DatasetBuilder.Builders
{
    public interface ILabelBuilder<TLabel, TAttributeArg, TAttributeKind>
    {
        IAttributeLimitsBuilder<TAttributeArg, TLabel> Label(TLabel value);
        IAttributeDefaultOrderingBuilder<TLabel, TAttributeArg, TAttributeKind> Ordering();
    }
}