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
using System.Collections;
using Iesi.Collections;

/// <summary>
/// Summary description for Customer
/// </summary>
public partial class SalesPerson : Person
{
    // Employee Information
    private string _employeeNumber;

    // Assigned Customers
    private ISet _assignedCustomers;

    // Constuctor
    public SalesPerson()
    {
    }

    // Properties

    public virtual String EmployeeNumber
    {
        get
        {
            return _employeeNumber;
        }
        set
        {
            _employeeNumber = value;
        }
    }

    public virtual ISet AssignedCustomers
    {
        get
        {
            return _assignedCustomers;
        }
        set
        {
            _assignedCustomers = value;
        }
    }
}