using ProjetoCursos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos.Repository.Repositorio
{
    public interface IProjetoCursosRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Alunos
        Task<Aluno[]> GetAllAlunoAsyncByName(string nome, bool includeCursos);
        Task<Aluno[]> GetAllAlunoAsync(bool includeProfessor);
        Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeCursos);

        //Cursos
        Task<Professor[]> GetAllProfessoresAsyncByName(string name, bool includeCursos);
        Task<Professor> GetAllProfessoresAsync(int ProfessorId, bool includeCursos);
    }
}
