using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeHospedar.Startup))]
namespace MeHospedar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
