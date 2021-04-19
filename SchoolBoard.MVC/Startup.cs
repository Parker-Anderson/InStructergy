using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolBoard.MVC.Startup))]
namespace SchoolBoard.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
