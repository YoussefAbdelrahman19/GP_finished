using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GradProjectV5.Startup))]
namespace GradProjectV5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
