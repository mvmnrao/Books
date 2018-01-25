<%@ Application Language="C#" %>

<script runat="server">

    void Application_EndRequest(object sender, EventArgs e)
    {
        NHibernateHelper.CloseSession();
    }
       
</script>
