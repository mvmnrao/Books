<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerOrdersExample.aspx.cs" Inherits="CustomerOrdersExample" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 800px;">
        <asp:HyperLink runat="server" NavigateUrl="~/CustomerOrdersExample.aspx" Text="Reset Page" /> |
        <asp:HyperLink runat="server" NavigateUrl="~/LazyLoadingExample.aspx" Text="Lazy Loading Example" />
        <br /><br /><br />
        <asp:LinkButton ID="lbtnAddCustomer" runat="server" OnClick="lbtnAddCustomer_Click" Style="float: right;">+ Add Customer</asp:LinkButton>
        <asp:GridView ID="gvCustomers" runat="server" DataSourceID="odsCustomers" DataKeyNames="PersonID" HeaderText="Customers"
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Vertical" Width="800px"
            EmptyDataText="No Customers Found - Add Some Customers">
            <Columns>
                <asp:BoundField DataField="PersonID" HeaderText="ID" ItemStyle-HorizontalAlign="Left" ReadOnly="true" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="City" HeaderText="City" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="State" HeaderText="State" ItemStyle-HorizontalAlign="Left" ControlStyle-Width="20px" />
                <asp:BoundField DataField="ZipCode" HeaderText="ZipCode" ItemStyle-HorizontalAlign="Left" ControlStyle-Width="50px" />
                <asp:CommandField ShowSelectButton="True" SelectText="View Orders"
                    ShowEditButton="True" EditText="Edit"
                    ShowDeleteButton="True" DeleteText="Delete" ItemStyle-Width="170px" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:ObjectDataSource ID="odsCustomers" runat="server"
            DataObjectTypeName="Customer" TypeName="Customer"
            OnSelected="odsCustomers_OnSelected"
            SelectMethod="getCustomers"
            UpdateMethod="saveOrUpdateCustomer"
            DeleteMethod="deleteCustomer" />
            
        <br /><br /><br />
        <asp:Literal ID="ltlSelectCustomer" runat="server">* You need to select a customer to add orders.</asp:Literal>
        <asp:LinkButton ID="lbtnAddProductOrder" runat="server" OnClick="lbtnAddProductOrder_Click" Style="float: right;">+ Add Order</asp:LinkButton>
        <asp:GridView ID="gvProductOrders" runat="server" DataSourceID="odsProductOrders" DataKeyNames="ProductOrderID" HeaderText="Customers"
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Vertical" Width="800px"
            EmptyDataText="No Orders Found - Select A Customer -or- Add Some Orders">
            <Columns>
                <asp:BoundField DataField="ProductOrderID" HeaderText="ID" ItemStyle-HorizontalAlign="Left" ReadOnly="true" />
                <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" ItemStyle-HorizontalAlign="Left" ReadOnly="true" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-HorizontalAlign="Left" ControlStyle-Width="25px" />
                <asp:BoundField DataField="TotalCost" HeaderText="TotalCost" ItemStyle-HorizontalAlign="Left" ControlStyle-Width="50px" />
                <asp:CommandField ShowEditButton="True" EditText="Edit"
                    ShowDeleteButton="True" DeleteText="Delete" ItemStyle-Width="100px" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:ObjectDataSource ID="odsProductOrders" runat="server"
            DataObjectTypeName="ProductOrder" TypeName="ProductOrder"
            OnSelected="odsProductOrders_OnSelected"
            SelectMethod="getProductOrdersForCustomer"
            UpdateMethod="saveOrUpdateProductOrder"
            DeleteMethod="deleteProductOrder">
            <SelectParameters>
              <asp:ControlParameter ControlID="gvCustomers" Name="customerID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
