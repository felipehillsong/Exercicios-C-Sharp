using Projeto_Heranca_MVC.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Heranca_MVC.Cliente
{
    public class ClienteTransacaoModel
    {
        public ClienteFisico ClienteFisico { get; set; }

        public ClienteJuridico ClienteJuridico { get; set; }
    }
}