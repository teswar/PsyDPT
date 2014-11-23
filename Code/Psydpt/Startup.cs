using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Psydpt.Startup))]
namespace Psydpt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
