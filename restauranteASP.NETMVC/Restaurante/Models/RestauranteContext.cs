using Microsoft.EntityFrameworkCore;

namespace Restaurante.Models {
    public class RestauranteContext : DbContext {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options) {

        }

        public DbSet<Pedido> Pedidos { get; set; }
    }
}
