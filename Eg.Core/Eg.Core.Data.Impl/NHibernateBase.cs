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
            TResult result;
            ITransaction tx = null;
            try
            {
                if (!session.Transaction.IsActive)
                {
                    tx = session.BeginTransaction();
                    result = func.Invoke();
                    tx.Commit();
                    return result;
                }
                return func.Invoke();
            }
            catch (Exception)
            {
                if (tx != null)
                {
                    tx.Rollback();
                }
                throw;
            }
            finally
            {
                if(tx != null)
                {
                    tx.Dispose();
                }
            }
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
