using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DatasetBuilder.Builders.Typed
{
    public class TypedAttributeDefaultOrderingBuilder<TLabel, TEntity, TAttribute> : AttributeDefaultOrderingBuilderBase<TLabel, Expression<Func<TEntity, TAttribute>>, PropertyInfo>
        where TLabel : Enum
    {
        internal TypedAttributeDefaultOrderingBuilder(LabelBuilderBase<TLabel, Expression<Func<TEntity, TAttribute>>, PropertyInfo> labelBuilder)
            : base(labelBuilder)
        {
        }

        private protected override PropertyInfo MapAttribute(Expression<Func<TEntity, TAttribute>> attribute)
        {
            return Extensions.GetPropertyInfo(attribute);
        }
    }
}
