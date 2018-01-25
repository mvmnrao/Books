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
/// Summary description for Customer
/// </summary>
public partial class Person
{
    private int? _personID;
    private string _firstName;
    private string _lastName;

    // Constuctor
    public Person()
    {
    }

    // Properties

    public virtual int? PersonID
    {
        get
        {
            return _personID;
        }
        set
        {
            _personID = value;
        }
    }

    public virtual string FirstName
    {
        get
        {
            return _firstName;
        }
        set
        {
            _firstName = value;
        }
    }

    public virtual string LastName
    {
        get
        {
            return _lastName;
        }
        set
        {
            _lastName = value;
        }
    }
}