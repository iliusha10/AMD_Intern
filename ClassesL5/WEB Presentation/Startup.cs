using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEB_Presentation.Startup))]
namespace WEB_Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
