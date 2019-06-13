using DatasetBuilder.AttributeNumberGenerators;
using DatasetBuilder.Builders;
using DatasetBuilder.Builders.Typed;
using DatasetBuilder.Orderings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DatasetBuilder
{
    public class TypedDatasetBuilder<TEntity, TAttribute, TLabel> : DatasetBuilderBase<TypedDataset<TEntity>, TEntity, Expression<Func<TEntity, TAttribute>>, Expression<Func<TEntity, TLabel>>, PropertyInfo, TLabel>
        where TEntity : new()
        where TAttribute : struct
        where TLabel : Enum
    {
        private readonly PropertyInfo _labelProperty;

        public TypedDatasetBuilder(Expression<Func<TEntity, TLabel>> label) 
            : this(label, NullOrdering.Instance, new EquidistantAttributeNumberGenerator())
        {
        }

        public TypedDatasetBuilder(Expression<Func<TEntity, TLabel>> label, IOrdering defaultOrdering) 
            : this(label, defaultOrdering, new EquidistantAttributeNumberGenerator())
        {
        }

        public TypedDatasetBuilder(Expression<Func<TEntity, TLabel>> label, IOrdering defaultOrdering, IAttributeNumberGenerator attributeNumberGenerator)
            : this(Extensions.GetPropertyInfo(label), defaultOrdering, attributeNumberGenerator)
        {
        }

        private TypedDatasetBuilder(PropertyInfo labelProperty, IOrdering defaultOrdering, IAttributeNumberGenerator attributeNumberGenerator)
            :base(attributeNumberGenerator, new TypedLabelBuilder<TEntity, TAttribute, TLabel>(labelProperty, OrderingBase.Coalesce(defaultOrdering)))
        {
            _labelProperty = labelProperty;
        }

        private protected override TEntity CreateEntity(TLabel labelValue, IEnumerable<AttributeValues<PropertyInfo>> attributesValues, int index)
        {
            var entity = new TEntity();

            _labelProperty.SetValue(entity, labelValue);

            foreach (var attributeValues in attributesValues)
            {
                var attrValuesArray = attributeValues.Values.ToArray();
                var value = attributeValues.Values.ElementAt(index);
                attributeValues.Attribute.SetValue(entity, Convert.ChangeType(value, typeof(TAttribute)));
            }

            return entity;
        }

        private protected override TypedDataset<TEntity> CreateDataset()
        {
            return new TypedDataset<TEntity>();
        }
    }
}
