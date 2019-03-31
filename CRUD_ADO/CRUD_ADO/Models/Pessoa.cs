using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_ADO.Models {
    public class Pessoa {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }

        public string Cargo { get; set; }

        public DateTime Data { get; set; }
        
    }
}