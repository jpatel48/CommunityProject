using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleProjectBootStrap.Startup))]
namespace SampleProjectBootStrap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
