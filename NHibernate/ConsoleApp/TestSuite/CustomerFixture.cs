using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainObjects.Entities;
using NHibernate;

namespace TestSuite
{
   
    [TestClass]
    public class CustomerFixture : BaseTestFixture
    {
        public CustomerFixture()
        {
           
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CanAddCustomer()
        {
            Customer customer = new Customer();
            customer.FirstName = "John";
            customer.LastName = "Doe";

            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(customer);
                    session.Flush();
                    session.Evict(customer);

                    Customer CVerify = session.Get<Customer>(customer.ID);
                    Assert.IsTrue(CVerify.ID != 0);

                    Assert.AreEqual(CVerify.FirstName, customer.FirstName);
                    Assert.AreEqual(CVerify.LastName, customer.LastName); 
                }
            }

        }
    }
}
