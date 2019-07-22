using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SklepKompMVC.Startup))]
namespace SklepKompMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
