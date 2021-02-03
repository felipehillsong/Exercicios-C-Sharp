using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCursos.Domain.Models
{
    public class ProfessorCurso
    {
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

    }
}
