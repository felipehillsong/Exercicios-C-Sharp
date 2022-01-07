using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using Restaurante.Interface;
using Restaurante.Models;

namespace Restaurante.Repository {
    public class PedidoRepository: IPedidoRepository {
        private readonly RestauranteContext _context;
        public PedidoRepository(RestauranteContext context) {
            _context = context;
        }
        public void Add(Pedido pedido) {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public List<Pedido> GetAll() {
            return _context.Pedidos.ToList();
        }
    }
}
