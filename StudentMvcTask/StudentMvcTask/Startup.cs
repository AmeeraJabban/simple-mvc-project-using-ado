using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentMvcTask.Startup))]
namespace StudentMvcTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
