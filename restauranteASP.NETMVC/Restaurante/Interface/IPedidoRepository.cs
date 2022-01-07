using Restaurante.Models;
using System.Collections.Generic;

namespace Restaurante.Interface {
    public interface IPedidoRepository {
        void Add(Pedido pedido);
        List<Pedido> GetAll();
    }
}
