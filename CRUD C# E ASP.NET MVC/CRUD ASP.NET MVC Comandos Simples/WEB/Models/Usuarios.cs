using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cargo { get; set; }

        public DateTime Data { get; set; }
    }
}