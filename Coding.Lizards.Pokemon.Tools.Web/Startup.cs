using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Coding.Lizards.Pokemon.Tools.Web.Startup))]
namespace Coding.Lizards.Pokemon.Tools.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
