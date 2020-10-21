using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlindajeOncer.Backend.Startup))]
namespace BlindajeOncer.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
