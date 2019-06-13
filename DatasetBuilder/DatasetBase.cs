using System.Collections.Generic;

namespace DatasetBuilder
{
    public abstract class DatasetBase<TEntity>
    {
        public IEnumerable<TEntity> Training { get; set; }
        public IEnumerable<TEntity> Validation { get; set; }
        public IEnumerable<TEntity> Test { get; set; }
    }
}
