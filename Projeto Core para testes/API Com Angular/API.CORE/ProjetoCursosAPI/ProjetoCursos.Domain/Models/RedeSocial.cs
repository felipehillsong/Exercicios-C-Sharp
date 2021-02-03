using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCursos.Domain.Models
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int? ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
