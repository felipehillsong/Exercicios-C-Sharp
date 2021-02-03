using Microsoft.EntityFrameworkCore;
using ProjetoCursos.Domain.Models;

namespace ProjetoCursos.Repository.Data
{
    public class ProjetoCursosContext : DbContext
    {
        public ProjetoCursosContext(DbContextOptions options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<ProfessorCurso> ProfessoresCursos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfessorCurso>().HasKey(PE => new { PE.CursoId, PE.ProfessorId });
        }
    }
}