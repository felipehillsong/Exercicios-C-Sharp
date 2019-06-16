using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_SIMPLIFICADO.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int CPF { get; set; }

        public int RG { get; set; }

        public int TelefoneFixo { get; set; }

        public int TelefoneCelular { get; set; }

        public string Endereco { get; set; }

        public string Email { get; set; }

        public string Observacoes { get; set; }
    }
}