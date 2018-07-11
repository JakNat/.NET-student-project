using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NET_student_project.Startup))]
namespace NET_student_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
