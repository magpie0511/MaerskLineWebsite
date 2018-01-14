using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaerskLineWebsite.Startup))]
namespace MaerskLineWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
