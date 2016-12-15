using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace SessionPerPresenter.Data
{
    public class SessionProvider : ISessionProvider
    {
        private readonly ISessionFactory _sessionFactory;
        private ISession _currentSession;

        public SessionProvider(ISessionFactory sessionFactory)
        {
            Console.WriteLine("Building session provider!");
            _sessionFactory = sessionFactory;
        }

        public void Dispose()
        {
            if (_currentSession != null)
            {
                _currentSession.Dispose();
            }
            _currentSession = null;
        }

        public void DisposeCurrentSession()
        {
            _currentSession.Dispose();
            _currentSession = null;
        }

        public ISession GetCurrentSession()
        {
            if (null == _currentSession)
            {
                _currentSession = _sessionFactory.OpenSession();
            }

            return _currentSession;
        }
    }
}
