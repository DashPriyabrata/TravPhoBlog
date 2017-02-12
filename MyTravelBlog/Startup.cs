using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTravelBlog.Startup))]
namespace MyTravelBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
