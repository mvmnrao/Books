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
public partial class Customer : Person
{
    // Address
    private string _address;
    private string _city;
    private string _state;
    private string _zipCode;

    // Order Information
    private ISet _orders;

    // Constuctor
    public Customer()
    {
    }

    // Properties

    public virtual string Address
    {
        get
        {
            return _address;
        }
        set
        {
            _address = value;
        }
    }

    public virtual string City
    {
        get
        {
            return _city;
        }
        set
        {
            _city = value;
        }
    }

    public virtual string State
    {
        get
        {
            return _state;
        }
        set
        {
            _state = value;
        }
    }

    public virtual string ZipCode
    {
        get
        {
            return _zipCode;
        }
        set
        {
            _zipCode = value;
        }
    }

    public virtual ISet Orders
    {
        get
        {
            return _orders;
        }
        set
        {
            _orders = value;
        }
    }
}