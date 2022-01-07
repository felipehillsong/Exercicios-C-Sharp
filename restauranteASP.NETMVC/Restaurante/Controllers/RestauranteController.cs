using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Interface;
using Restaurante.Models;
using Restaurante.Repository;

namespace Restaurante.Controllers
{
    public class RestauranteController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        public RestauranteController(IPedidoRepository pedidoRepository) {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public ActionResult Pedidos() {
            return View(_pedidoRepository.GetAll());
        }

        [HttpPost]
        public ActionResult Pedidos(Pedido pedido) {
            _pedidoRepository.Add(pedido);

            return View(_pedidoRepository.GetAll());
        }

    }
}