<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LazyLoadingExample.aspx.cs" Inherits="LazyLoadingExample" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink runat="server" NavigateUrl="~/LazyLoadingExample.aspx" Text="Reset Page" /> |
        <asp:HyperLink runat="server" NavigateUrl="~/CustomerOrdersExample.aspx" Text="Customers/Orders Example" />
        <br /><br />
        Step through these examples using the debugger and you will see how lazy loading doesn't load data until it is needed.
        <br /><br />
        Customer w/ Orders Example:
        <asp:BulletedList ID="blCustomerEx" runat="server" BulletStyle="Square">
        </asp:BulletedList>
        Sales Person w/ Assigned Customers Example:
        <asp:BulletedList ID="blSalesPersonEx" runat="server" BulletStyle="Square">
        </asp:BulletedList>
    </div>
    </form>
</body>
</html>
