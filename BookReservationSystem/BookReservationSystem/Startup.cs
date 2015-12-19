using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookReservationSystem.Startup))]
namespace BookReservationSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
