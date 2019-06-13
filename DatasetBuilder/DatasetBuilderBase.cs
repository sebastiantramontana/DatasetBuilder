using DatasetBuilder.AttributeNumberGenerators;
using DatasetBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatasetBuilder
{
    public abstract class DatasetBuilderBase<TDataset, TEntity, TAttributeArg, TLabelArg, TAttributeKind, TLabel>
        where TDataset : DatasetBase<TEntity>
    {
        private readonly IAttributeNumberGenerator _attributeNumberGenerator;
        private readonly LabelBuilderBase<TLabel, TAttributeArg, TAttributeKind> _labelBuilder;

        private protected DatasetBuilderBase(IAttributeNumberGenerator attributeNumberGenerator, LabelBuilderBase<TLabel, TAttributeArg, TAttributeKind> labelBuilder)
        {
            _attributeNumberGenerator = attributeNumberGenerator ?? new EquidistantAttributeNumberGenerator();
            _labelBuilder = labelBuilder;
            this.LabelsConfigurations = _labelBuilder.GetLabels();
        }

        public ILabelBuilder<TLabel, TAttributeArg, TAttributeKind> Configure()
        {
            return _labelBuilder;
        }

        public TDataset Generate(int trainingCount, int validationCount, int testCount)
        {
            ValidateLabels();

            var dataset = CreateDataset();

            dataset.Training = BuildEntities(trainingCount);
            dataset.Validation = BuildEntities(validationCount);
            dataset.Test = BuildEntities(testCount);

            return dataset;
        }

        private protected IEnumerable<ILabelConfiguration<TLabel, TAttributeKind>> LabelsConfigurations { get; }

        private IEnumerable<TEntity> BuildEntities(int count)
        {
            if (count < 1)
            {
                return new TEntity[] { };
            }

            var entities = new List<TEntity>(count);

            foreach (var labelconf in this.LabelsConfigurations)
            {
                var attributesValues = _attributeNumberGenerator.Generate(labelconf.AttributesLimits, count);

                for (int i = 0; i < count; i++)
                {
                    var entity = CreateEntity(labelconf.LabelValue, attributesValues, i);
                    entities.Add(entity);
                }
            }

            return entities;
        }

        private void ValidateLabels()
        {
            if (this.LabelsConfigurations == null || this.LabelsConfigurations.Count() < 1)
            {
                throw new InvalidOperationException($"No labels found. At least, 1 label must be added");
            }

            const int NOT_INITIALIZED = -1;
            var attribCount = NOT_INITIALIZED;

            foreach (var lab in this.LabelsConfigurations)
            {
                var count = lab.AttributesLimits.Count();

                if (count < 1)
                {
                    throw new InvalidOperationException($"Must there are 1 attribute limit at least for label {lab.LabelValue}");
                }

                if (attribCount == NOT_INITIALIZED)
                {
                    attribCount = count;
                }
                else
                {
                    if (count != attribCount)
                    {
                        throw new InvalidOperationException("Attribute limits must be the same for all labels");
                    }
                }
            }
        }

        private protected abstract TEntity CreateEntity(TLabel labelValue, IEnumerable<AttributeValues<TAttributeKind>> attributeValues, int index);
        private protected abstract TDataset CreateDataset();
    }
}
