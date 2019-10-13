using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Loja.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public DateTime UltimaCompra { get; set; }

        public float Estoque { get; set; }

        public string Comentario { get; set; }
    }
}