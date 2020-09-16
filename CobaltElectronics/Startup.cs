using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CobaltElectronics.Startup))]
namespace CobaltElectronics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
