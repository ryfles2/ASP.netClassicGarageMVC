using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(classicGarage.Startup))]
namespace classicGarage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
