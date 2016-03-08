using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PhotoAlbum.WEB.Startup))]
namespace PhotoAlbum.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureDependencyInjection(app);
        }
    }
}
