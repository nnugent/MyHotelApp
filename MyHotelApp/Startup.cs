using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyHotelApp.Startup))]
namespace MyHotelApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
