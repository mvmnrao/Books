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
public partial class SalesPerson
{
    public static SalesPerson getSalesPerson(int? salesPersonID)
    {
        // Open the session
        ISession session = NHibernateHelper.GetCurrentSession();

        // Load the order from the database
        SalesPerson salesPerson = (SalesPerson)session.Load(typeof(SalesPerson), salesPersonID);

        return salesPerson;
    }

    public static List<SalesPerson> getSalesPersons()
    {
        List<SalesPerson> salesPersons = new List<SalesPerson>();
        
        // Open the session
        ISession session = NHibernateHelper.GetCurrentSession();

        // Load the customers from the database
        session.CreateCriteria(typeof(SalesPerson)).List(salesPersons);

        return salesPersons;
    }

    public static void saveOrUpdateSalesPerson(Customer salesPerson)
    {
        ISession session = NHibernateHelper.GetCurrentSession();
        ITransaction transaction = null;

        try
        {
            // Start transaction
            transaction = session.BeginTransaction();

            // Save or update (saves if the id is null, otherwise it updates)
            session.SaveOrUpdate(salesPerson);

            // Commit transaction
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
    }

    public static void deleteSalesPerson(SalesPerson salesPerson)
    {
        ISession session = NHibernateHelper.GetCurrentSession();
        ITransaction transaction = null;

        try
        {
            // Start transaction
            transaction = session.BeginTransaction();

            // Delete
            session.Delete(salesPerson);

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