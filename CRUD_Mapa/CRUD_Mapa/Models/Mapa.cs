using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_Mapa.Models
{
    public class Mapa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal? Latitude { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal? Longitude { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
    }
}