using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Tuple;
using System.Reflection;

namespace DomainObjects.Managers
{
    public class DomainManager<T>
    {
        protected static NHibernate.Cfg.Configuration cfg;
        protected static ISessionFactory sessionFactory;

        static DomainManager()
        {
            cfg = new NHibernate.Cfg.Configuration();
            cfg.AddAssembly("DomainObjects");
            sessionFactory = cfg.BuildSessionFactory(); 
        }

        public static IList<T> GetAll()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria(typeof(T)).List<T>();                
            }
        }

        public static T GetById(int id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {                
                return session.Get<T>(id); 
            }
        }

        public static bool Delete(T item)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(item);
                    transaction.Commit();

                    return (session.Get<T>(GetId(item)) == null); 
                }
            }          
        }

        public static void Save(T item)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(item);
                    
                    transaction.Commit(); 
                }
            }
        }

        private static int GetId(T item)
        {
            PropertyInfo property = item.GetType().GetProperty("Id");
            return (int) property.GetValue(item, null);
        }

       
    }
}
