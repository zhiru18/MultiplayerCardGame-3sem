using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebGameClient.Startup))]
namespace WebGameClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
