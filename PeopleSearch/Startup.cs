using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PeopleSearch.Startup))]
namespace PeopleSearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
