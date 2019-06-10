using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OurForumDemo.Startup))]
namespace OurForumDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
