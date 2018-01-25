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
using NHibernate.Expression;

/// <summary>
/// Summary description for ProductOrder
/// </summary>
public partial class ProductOrder
{

    public static ProductOrder getProductOrder(int? orderID)
    {
        // Get the session
        ISession session = NHibernateHelper.GetCurrentSession();

        // Load the order from the database
        ProductOrder order = (ProductOrder)session.Load(typeof(ProductOrder), orderID);

        return order;
    }

    public static List<ProductOrder> getProductOrdersForCustomer(int? customerID)
    {
        List<ProductOrder> orders = new List<ProductOrder>();

        // Get the session
        ISession session = NHibernateHelper.GetCurrentSession();

        // Load the order from the database
        ICriteria criteria = session.CreateCriteria(typeof(ProductOrder));
        criteria.Add(Expression.Eq("CustomerID", customerID));
        criteria.List(orders);

        return orders;
    }

    public static void saveOrUpdateProductOrder(ProductOrder order)
    {
        ISession session = NHibernateHelper.GetCurrentSession();
        ITransaction transaction = null;

        try
        {
            // Start transaction
            transaction = session.BeginTransaction();

            // Save or update (saves if the id is null, otherwise it updates)
            session.SaveOrUpdate(order);

            // Commit transaction
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
    }

    public static void deleteProductOrder(ProductOrder order)
    {
        ISession session = NHibernateHelper.GetCurrentSession();
        ITransaction transaction = null;

        try
        {
            // Start transaction
            transaction = session.BeginTransaction();

            // Delete
            session.Delete(order);

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