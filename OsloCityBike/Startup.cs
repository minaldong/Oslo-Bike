using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OsloCityBike.Startup))]
namespace OsloCityBike
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
