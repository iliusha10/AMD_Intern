using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Infrastructure.IoC;

namespace WEB_Presentation
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ServiceLocator.RegisterAll();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            NHibernateProfiler.Initialize();
        }
    }
}