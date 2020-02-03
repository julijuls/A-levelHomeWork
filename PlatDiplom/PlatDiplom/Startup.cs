using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlatDiplom.Startup))]
namespace PlatDiplom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
