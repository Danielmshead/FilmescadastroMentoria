using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FILMECRUD.Startup))]
namespace FILMECRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
