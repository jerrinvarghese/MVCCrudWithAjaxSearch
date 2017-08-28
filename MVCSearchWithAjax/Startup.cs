using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSearchWithAjax.Startup))]
namespace MVCSearchWithAjax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
