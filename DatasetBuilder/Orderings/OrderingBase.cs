using System;
using System.Collections.Generic;

namespace DatasetBuilder.Orderings
{
    public abstract class OrderingBase : IOrdering
    {
        private readonly string _name;
        private readonly Guid _objId;

        private protected OrderingBase(string name)
        {
            _name = name;
            _objId = Guid.NewGuid();
        }

        public static bool IsNull(IOrdering ordering)
        {
            return (ordering == null || (ordering is OrderingBase ord && ord == NullOrdering.Instance));
        }

        public static IOrdering Coalesce(IOrdering ordering)
        {
            return Coalesce(ordering, OrderingFactory.None);
        }

        public static IOrdering Coalesce(IOrdering ordering, IOrdering nullResult)
        {
            return IsNull(ordering) ? nullResult : ordering;
        }

        public abstract IEnumerable<double> Order(IEnumerable<double> values);

        public bool Equals(OrderingBase other)
        {
            return other == this;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as OrderingBase);
        }

        public override int GetHashCode()
        {
            return _objId.GetHashCode();
        }

        public override string ToString()
        {
            return _name;
        }

        public static bool operator ==(OrderingBase o1, OrderingBase o2)
        {
            return (!ReferenceEquals(o1, null)) && (!ReferenceEquals(o2, null)) && o1._objId == o2._objId;
        }

        public static bool operator !=(OrderingBase o1, OrderingBase o2)
        {
            return !(o1 == o2);
        }
    }
}
