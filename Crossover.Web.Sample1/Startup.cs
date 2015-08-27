using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Crossover.Web.Sample1.Startup))]
namespace Crossover.Web.Sample1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
