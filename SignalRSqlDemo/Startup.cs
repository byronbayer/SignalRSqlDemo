using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalRSqlDemo.Startup))]
namespace SignalRSqlDemo
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
