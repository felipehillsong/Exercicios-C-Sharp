using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sistema_Pedido.Startup))]
namespace Sistema_Pedido
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
