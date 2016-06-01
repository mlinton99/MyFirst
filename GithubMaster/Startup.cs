using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GithubMaster.Startup))]
namespace GithubMaster
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
