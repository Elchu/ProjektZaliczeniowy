using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpeedRacing.Startup))]
namespace SpeedRacing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
