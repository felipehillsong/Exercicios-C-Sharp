using Sistema_Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Loja.ViewModels
{
    public class OrdemView
    {
        public Customizar Customizar { get; set; }
        public List<ProdutoOrdem> ProdutoOrdem { get; set; }
    }
}