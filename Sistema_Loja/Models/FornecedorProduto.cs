using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Loja.Models
{
    public class FornecedorProduto
    {
        [Key]
        public int FornecedorProdutoId { get; set; }       
        public int FornecedorId { get; set; }
        public int ProdutoId { get; set; }

        public virtual Fornecdedor Fornecdedor { get; set; }
        public virtual Produto Produto { get; set; }


    }
}