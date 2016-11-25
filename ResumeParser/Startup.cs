using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResumeParser.Startup))]
namespace ResumeParser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
