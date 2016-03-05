using AutoMapper;
using Data.Layer.Models;
using GameDay.Models;
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
            app.MapSignalR();
        }
    }
}
