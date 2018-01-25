using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using NHibernate;

/// <summary>
/// Summary description for Customer
/// </summary>
public partial class Customer
{
    public static Customer getCustomer(int? customerID)
    {
        // Open the session
        ISession session = NHibernateHelper.GetCurrentSession();

        // Load the order from the database
        Customer customer = (Customer)session.Load(typeof(Customer), customerID);

        return customer;
    }

    public static List<Customer> getCustomers()
    {
        List<Customer> customers = new List<Customer>();
        
        // Open the session
        ISession session = NHibernateHelper.GetCurrentSession();

        // Load the customers from the database
        session.CreateCriteria(typeof(Customer)).List(customers);

        return customers;
    }

    public static void saveOrUpdateCustomer(Customer customer)
    {
        ISession session = NHibernateHelper.GetCurrentSession();
        ITransaction transaction = null;

        try
        {
            // Start transaction
            transaction = session.BeginTransaction();

            // Save or update (saves if the id is null, otherwise it updates)
            session.SaveOrUpdate(customer);

            // Commit transaction
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
    }

    public static void deleteCustomer(Customer customer)
    {
        ISession session = NHibernateHelper.GetCurrentSession();
        ITransaction transaction = null;

        try
        {
            // Start transaction
            transaction = session.BeginTransaction();

            // Delete
            session.Delete(customer);

            // Commit transaction
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
    }
}