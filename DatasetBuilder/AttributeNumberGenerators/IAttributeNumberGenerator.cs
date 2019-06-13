using DatasetBuilder.Builders;
using System.Collections.Generic;

namespace DatasetBuilder.AttributeNumberGenerators
{
    public interface IAttributeNumberGenerator
    {
        IEnumerable<AttributeValues<TAttributeKind>> Generate<TAttributeKind>(IEnumerable<IAttributeLimits<TAttributeKind>> limits, int countByLimits);
    }
}
