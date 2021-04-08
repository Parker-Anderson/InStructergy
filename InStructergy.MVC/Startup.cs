using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InStructergy.MVC.Startup))]
namespace InStructergy.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
