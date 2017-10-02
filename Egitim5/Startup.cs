using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Egitim5.Startup))]
namespace Egitim5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
