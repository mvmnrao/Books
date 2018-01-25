using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Cfg;
using NHibernate; 

namespace TestSuite
{
    public class BaseTestFixture 
    {
        protected static NHibernate.Cfg.Configuration _config;
        protected static ISessionFactory _sessionFactory;

        static BaseTestFixture()
        {
            _config = new NHibernate.Cfg.Configuration();
            _config.AddAssembly("DomainObjects");

            if (_sessionFactory == null)
            {
                _sessionFactory = _config.BuildSessionFactory(); 
            }            
        }             
    }
}
