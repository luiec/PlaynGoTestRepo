using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoffeeWebApp.Startup))]
namespace CoffeeWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
