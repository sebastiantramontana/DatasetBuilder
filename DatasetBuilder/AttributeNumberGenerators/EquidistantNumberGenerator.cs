using DatasetBuilder.Builders;
using System;
using System.Collections.Generic;

namespace DatasetBuilder.AttributeNumberGenerators
{
    internal class EquidistantAttributeNumberGenerator : IAttributeNumberGenerator
    {
        private readonly Random _random;

        internal EquidistantAttributeNumberGenerator()
        {
            _random = new Random((int)DateTime.Now.Ticks * 13);
        }

        public IEnumerable<AttributeValues<TAttributeKind>> Generate<TAttributeKind>(IEnumerable<IAttributeLimits<TAttributeKind>> attrbutesLimits, int count)
        {
            var attributesValues = new List<AttributeValues<TAttributeKind>>(count);

            foreach (var attrLimits in attrbutesLimits)
            {
                var values = new List<double>(count);

                for (int i = 0; i < count; i++)
                {
                    var currentLimits = attrLimits.Limits;
                    var piece = (currentLimits.Max - currentLimits.Min) / count;
                    var minLimit = currentLimits.Min + piece * i;
                    var maxLimit = minLimit + piece;

                    var value = _random.Next(new Limits(minLimit, maxLimit));
                    values.Add(value);
                }

                attributesValues.Add(new AttributeValues<TAttributeKind>(attrLimits.Attribute, attrLimits.Ordering.Order(values)));
            }

            return attributesValues;
        }
    }
}
