using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante.Models {
    public class Pedido {
        public Pedido() {
            Data = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Mesa { get; set; }

        public string Pratos { get; set; }

        public int QtdPratos { get; set; }

        public string Bebidas { get; set; }

        public int QtdBebidas { get; set; }

        public string Sobremesas { get; set; }

        public int QtdSobremesas { get; set; }

        public DateTime Data { get; set; }

    }
}
