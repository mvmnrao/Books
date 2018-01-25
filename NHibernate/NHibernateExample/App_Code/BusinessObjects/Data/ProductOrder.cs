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

/// <summary>
/// Summary description for ProductOrder
/// </summary>
public partial class ProductOrder
{
    private int? _productOrderID;
    private int? _customerID;

    // Order Information
    private string _productName;
    private int _quantity;
    private decimal _totalCost;

    // Constuctor
    public ProductOrder()
    {
    }

    // Properties

    public virtual int? ProductOrderID
    {
        get
        {
            return _productOrderID;
        }
        set
        {
            _productOrderID = value;
        }
    }

    public virtual int? CustomerID
    {
        get
        {
            return _customerID;
        }
        set
        {
            _customerID = value;
        }
    }

    public virtual string ProductName
    {
        get
        {
            return _productName;
        }
        set
        {
            _productName = value;
        }
    }

    public virtual int Quantity
    {
        get
        {
            return _quantity;
        }
        set
        {
            _quantity = value;
        }
    }

    public virtual decimal TotalCost
    {
        get
        {
            return _totalCost;
        }
        set
        {
            _totalCost = value;
        }
    }
}