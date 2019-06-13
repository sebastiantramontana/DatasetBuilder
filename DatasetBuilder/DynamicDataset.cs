using System.Collections.Generic;

namespace DatasetBuilder
{
    public class DynamicDataset : DatasetBase<DynamicEntity>
    {
        public DynamicDataset(IEnumerable<string> attributes)
        {
            this.Attributes = attributes;
        }

        public IEnumerable<string> Attributes { get; }
    }
}
