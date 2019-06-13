using DatasetBuilder.Orderings;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DatasetBuilder.Builders.Typed
{
    public class TypedAttributeLimitsBuilder<TEntity, TAttribute, TLabel> : AttributeLimitsBuilderBase<Expression<Func<TEntity, TAttribute>>, PropertyInfo, TLabel>
        where TLabel : Enum
        where TAttribute : struct
    {
        internal TypedAttributeLimitsBuilder(TLabel labelValue, LabelBuilderBase<TLabel, Expression<Func<TEntity, TAttribute>>, PropertyInfo> labelBuilder, IOrdering defaultOrdering)
            : base(labelValue, labelBuilder, defaultOrdering)
        {
        }

        private protected override PropertyInfo MapAttribute(Expression<Func<TEntity, TAttribute>> attribute)
        {
            return Extensions.GetPropertyInfo(attribute);
        }
    }
}
