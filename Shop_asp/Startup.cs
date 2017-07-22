using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shop_asp.Startup))]
namespace Shop_asp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
