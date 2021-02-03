using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCursos.Domain.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public List<ProfessorCurso> ProfessoresCursos { get; set; }
    }
}
