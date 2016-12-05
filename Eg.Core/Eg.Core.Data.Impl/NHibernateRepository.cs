using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace Eg.Core.Data.Impl
{
    public class NHibernateRepository<T>: NHibernateBase, IRepository<T> where T: Entity
    {
        public NHibernateRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        public int Count
        {
            get
            {
                return Transact(() => session.Query<T>().Count());
            }
        }

        public void Add(T item)
        {
            Transact(() =>
                session.Save(item));
        }

        public bool Contains(T item)
        {
            if (item.Id == default(Guid))
                return false;

            return Transact(() => session.Get<T>(item.Id)) != null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Transact(() => session.Query<T>()
            .Take(1000).GetEnumerator());
        }

        public bool Remove(T item)
        {
            Transact(() => session.Delete(item));
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Transact(() => GetEnumerator());
        }
    }
}
