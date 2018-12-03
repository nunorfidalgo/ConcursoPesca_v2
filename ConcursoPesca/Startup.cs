using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConcursoPesca.Startup))]
namespace ConcursoPesca
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
