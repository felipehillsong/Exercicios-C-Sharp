using ProjetoCursos.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCursos.Domain.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }        
        public DateTime Nascimento { get; set; }
        public int Telefone { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
        public string ImagemURL { get; set; }
        public List<Curso> Cursos { get; set; }
        public List<RedeSocial> RedesSociais { get; set; }
        public List<ProfessorCurso> ProfessoresCursos { get; set; }
    }
}
