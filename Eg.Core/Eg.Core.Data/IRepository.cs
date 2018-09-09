using System;
using System.Collections.Generic;

namespace Eg.Core.Data
{
    public interface IRepository<T, TId>: IEnumerable<T> where T : Entity<TId>
    {
        void Add(T item);
        void Update(T item);
        bool Contains(T item);
        bool Contains(Func<T, bool> predicate);
        int Count { get; }
        bool Remove(T item);
    }
}
