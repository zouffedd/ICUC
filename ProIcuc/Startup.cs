using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProIcuc.Startup))]
namespace ProIcuc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
