using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MailHelper.Startup))]
namespace MailHelper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
