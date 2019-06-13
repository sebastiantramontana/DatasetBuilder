using DatasetBuilder.AttributeNumberGenerators;
using DatasetBuilder.Builders;
using DatasetBuilder.Builders.Dynamic;
using DatasetBuilder.Orderings;
using System.Collections.Generic;
using System.Linq;

namespace DatasetBuilder
{
    public class DynamicDatasetBuilder : DatasetBuilderBase<DynamicDataset, DynamicEntity,string, string, string, string>
    {
        public DynamicDatasetBuilder() : this(NoOrdering.Instance, new EquidistantAttributeNumberGenerator())
        {
        }

        public DynamicDatasetBuilder(IOrdering defaultOrdering) : this(defaultOrdering, new EquidistantAttributeNumberGenerator())
        {
        }

        public DynamicDatasetBuilder(IOrdering defaultOrdering, IAttributeNumberGenerator attributeNumberGenerator)
            : base(attributeNumberGenerator, new DynamicLabelBuilder(OrderingBase.Coalesce(defaultOrdering)))
        {
        }

        private protected override DynamicEntity CreateEntity(string labelValue, IEnumerable<AttributeValues<string>> attributesValues, int index)
        {
            var attributesArray = attributesValues.ToArray();
            var values = new double[attributesArray.Length];

            for (int j = 0; j < attributesArray.Length; j++)
            {
                var attrValuesArray = attributesArray[j].Values.ToArray();
                var value = attrValuesArray[index];
                values[j] = value;
            }

            return new DynamicEntity(labelValue, values); ;
        }

        private protected override DynamicDataset CreateDataset()
        {
            var labelsConf = this.LabelsConfigurations;
            var attributes = labelsConf.First().AttributesLimits.Select(a => a.Attribute).ToArray();
            return new DynamicDataset(attributes);
        }
    }
}
