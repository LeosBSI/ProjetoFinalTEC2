using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoAdlinMVC.Startup))]
namespace ProjetoAdlinMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
