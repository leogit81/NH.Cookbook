using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eg.Core.Data
{
    public interface IRepository<T, TId>: IEnumerable<T> where T : Entity<TId>
    {
        void Add(T item);
        bool Contains(T item);
        int Count { get; }
        bool Remove(T item);
    }
}
