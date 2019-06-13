using DatasetBuilder.Orderings;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DatasetBuilder.Builders.Typed
{
    public class TypedLabelBuilder<TEntity, TAttribute, TLabel> : LabelBuilderBase<TLabel, Expression<Func<TEntity, TAttribute>>, PropertyInfo>
        where TAttribute : struct
        where TLabel : Enum
    {
        public TypedLabelBuilder(PropertyInfo labelProp, IOrdering defaultOrdering)
            : base(defaultOrdering)
        {

        }

        private protected override AttributeDefaultOrderingBuilderBase<TLabel, Expression<Func<TEntity, TAttribute>>, PropertyInfo> CreateAttributeDefaultOrderingBuilder(LabelBuilderBase<TLabel, Expression<Func<TEntity, TAttribute>>, PropertyInfo> labelBuilder)
        {
            return new TypedAttributeDefaultOrderingBuilder<TLabel, TEntity, TAttribute>(labelBuilder);
        }

        private protected override AttributeLimitsBuilderBase<Expression<Func<TEntity, TAttribute>>, PropertyInfo, TLabel> CreateAttributeLimitsBuilder(TLabel labelValue, LabelBuilderBase<TLabel, Expression<Func<TEntity, TAttribute>>, PropertyInfo> labelBuilder, IOrdering defaultOrdering)
        {
            return new TypedAttributeLimitsBuilder<TEntity, TAttribute, TLabel>(labelValue, labelBuilder, defaultOrdering);
        }
    }
}
