﻿using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionPerPresenter.Data
{
    public interface ISessionProvider: IDisposable
    {
        ISession GetCurrentSession();
        void DisposeCurrentSession();
    }
}
