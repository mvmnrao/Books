using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NHibernate;
using NHibernate.Cfg;
using System.IO;
using System.Reflection;

/// <summary>
/// Summary description for NHibernateHelper
/// </summary>
public sealed class NHibernateHelper
{
    private const string sessionKey = "nhibernate.current_session";
    private static readonly ISessionFactory sessionFactory;

    static NHibernateHelper()
    {
        log4net.Config.XmlConfigurator.Configure();

        // Get the mapping file path
        String mappingPath = HttpContext.Current.Server.MapPath("/NHibernateExample/App_Code/BusinessObjects/Mappings/");

        // Setup the configuration
        Configuration config = new Configuration()
            .AddFile(mappingPath + "Person.hbm.xml")
            .AddFile(mappingPath + "ProductOrder.hbm.xml");

        // Build the session factory
        sessionFactory = config.BuildSessionFactory();
    }

    public static ISession GetCurrentSession()
    {
        HttpContext context = HttpContext.Current;
        ISession currentSession = (ISession)context.Items[sessionKey];

        if (currentSession == null)
        {
            currentSession = sessionFactory.OpenSession();
            context.Items[sessionKey] = currentSession;
        }

        return currentSession;
    }

    public static void CloseSession()
    {
        HttpContext context = HttpContext.Current;
        ISession currentSession = (ISession)context.Items[sessionKey];

        if (currentSession == null)
        {
            // No current session
            return;
        }

        currentSession.Close();
        context.Items.Remove(sessionKey);
    }

    public static void CloseSessionFactory()
    {
        if (sessionFactory != null)
        {
            sessionFactory.Close();
        }
    }
}