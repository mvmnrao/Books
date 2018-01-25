using System;
using System.Collections.Generic;
using System.Text;
using DomainObjects;
using NHibernate;
using DomainObjects.Managers;
using System.Xml;
using System.Collections;

namespace SchoolAppConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
            cfg.AddAssembly("DomainObjects");

            ISessionFactory sessionFactory = cfg.BuildSessionFactory();

            
           
        }


    }
}
