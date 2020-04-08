using EstacionamentoESilva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoESilva.Acesso
{
    public class AcessoAsClasses
    {
        public Cliente Cliente { get; set; }

        public Veiculo Veiculo { get; set; }

        public Funcionario Funcionario { get; set; }

        public Servico Servico { get; set; }
    }
}