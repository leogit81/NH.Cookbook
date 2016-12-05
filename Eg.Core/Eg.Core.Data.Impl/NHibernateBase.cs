using NHibernate;
using System;

namespace Eg.Core.Data.Impl
{
    public abstract class NHibernateBase
    {
        protected readonly ISessionFactory _sessionFactory;

        protected virtual ISession session
        {
            get
            {
                return _sessionFactory.GetCurrentSession();
            }
        }

        public NHibernateBase(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        protected virtual TResult Transact<TResult>(Func<TResult> func)
        {
            if (!session.Transaction.IsActive)
            {
                TResult result;
                using (var tx = session.BeginTransaction())
                {
                    result = func.Invoke();
                    tx.Commit();
                }
                return result;
            }
            return func.Invoke();
        }

        protected virtual void Transact (Action action)
        {
            Transact<bool>(() =>
            {
                action.Invoke();
                return false;
            });
        }
    }
}
