using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameDay.Startup))]
namespace GameDay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
