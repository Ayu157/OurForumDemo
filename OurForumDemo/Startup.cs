using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OurForum.Startup))]
namespace OurForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
