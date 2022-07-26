using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContanctListApp_v2.Startup))]
namespace ContanctListApp_v2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
