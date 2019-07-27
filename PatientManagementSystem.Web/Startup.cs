using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PatientManagementSystem.Web.Startup))]
namespace PatientManagementSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
