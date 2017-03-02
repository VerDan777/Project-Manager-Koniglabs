using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_Manager.Startup))]
namespace Project_Manager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
