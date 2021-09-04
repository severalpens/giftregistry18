using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GR2018.UI.Startup))]
namespace GR2018.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
