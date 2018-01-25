using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public partial class CustomerOrdersExample : System.Web.UI.Page
{
    private bool isAddCustomer = false;
    private bool isAddOrder = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        ltlSelectCustomer.Visible = false;
    }

    protected void lbtnAddCustomer_Click(object sender, EventArgs e)
    {
        isAddCustomer = true;
        gvCustomers.EditIndex = 0;
    }

    protected void odsCustomers_OnSelected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //Add empty record for the first row
        if (isAddCustomer)
        {
            List<Customer> customers = (List<Customer>)e.ReturnValue;

            Customer newCustomer = new Customer();
            newCustomer.LastName = "New Customer";
            
            customers.Insert(0, newCustomer);
        }
    }

    protected void lbtnAddProductOrder_Click(object sender, EventArgs e)
    {
        if (gvCustomers.SelectedValue != null)
        {

            isAddOrder = true;
            gvProductOrders.EditIndex = 0;
        }
        else
        {
            ltlSelectCustomer.Visible = true;
        }
    }

    protected void odsProductOrders_OnSelected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //Add empty record for the first row
        if (isAddOrder)
        {
            List<ProductOrder> orders = (List<ProductOrder>)e.ReturnValue;

            ProductOrder newProductOrder = new ProductOrder();
            newProductOrder.ProductName = "New Order";
            newProductOrder.CustomerID = (int?)gvCustomers.SelectedValue;

            orders.Insert(0, newProductOrder);
        }
    }
}
