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
using log4net;

public partial class LazyLoadingExample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // --- Lazy Loading Examples ---
        // Use debugging to step through these examples.  
        // Check your nhibernate log as you go through.
        // The logs will show you what queries are run and when.
        runCustomerExample();
        runSalesPersonExample();
    }

    private void runCustomerExample()
    {
        // --- Customer Example (One-To-Many) ---
        blCustomerEx.Items.Add("Get a customer object using hibernate.");

        int? customerID = 1; // Change this value based on your data
        Customer customer = Customer.getCustomer(customerID);

        if (customer != null)
        {
            blCustomerEx.Items.Add("Customer retrieved is: " + customer.LastName + ", " + customer.FirstName);

            // Note that the customer orders are mapped but they have not been retreived yet due to lazy loading.

            // Now read the orders.  Lazy loading will perform a query now to retrieve them.
            if (customer.Orders.Count > 0)
            {
                foreach (ProductOrder order in customer.Orders)
                {
                    blCustomerEx.Items.Add("Customer order: " + order.ProductName);
                }
            }
            else
            {
                blCustomerEx.Items.Add("No customer orders found.");
            }
        }
        else
        {
            blCustomerEx.Items.Add("No customer found");
        }
    }

    private void runSalesPersonExample()
    {
        // --- SalesPerson Example (Many-To-Many) ---
        blSalesPersonEx.Items.Add("Get a salesperson object using hibernate.");

        int? salesPersonID = 7; // Change this value based on your data
        SalesPerson salesPerson = SalesPerson.getSalesPerson(salesPersonID);

        if (salesPerson != null)
        {
            blSalesPersonEx.Items.Add("SalesPerson retrieved is: " + salesPerson.LastName + ", " + salesPerson.FirstName);

            // Note that the customer orders are mapped but they have not been retreived yet due to lazy loading.

            // Now read the assigned customers.  Lazy loading will perform a query now to retrieve them.
            if (salesPerson.AssignedCustomers.Count > 0)
            {
                foreach (Customer assignedCustomer in salesPerson.AssignedCustomers)
                {
                    blSalesPersonEx.Items.Add("Assigned customer: " + assignedCustomer.LastName + ", " + assignedCustomer.FirstName);
                }
            }
            else
            {
                blSalesPersonEx.Items.Add("No assigned customers found.");
            }
        }
        else
        {
            blSalesPersonEx.Items.Add("No customer found");
        }
    }
}
