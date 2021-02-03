using Microsoft.EntityFrameworkCore;
using ProjetoCursos.Domain.Models;
using ProjetoCursos.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos.Repository.Repositorio
{
    public class ProjetoCursosRepository : IProjetoCursosRepository
    {
        private readonly ProjetoCursosContext _context;
        public ProjetoCursosRepository(ProjetoCursosContext context)
        {
            _context = context;
        }

        //GERAIS
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //ALUNO
        public async Task<Aluno[]> GetAllAlunoAsyncByName(string nome, bool includeCursos)
        {
            IQueryable<Aluno> query = _context.Alunos.Include(c => c.Cursos).Include(c => c.RedesSociais);
            if (includeCursos)
            {
                query = query.Include(pr => pr.ProfessoresCursos).ThenInclude(p => p.Professor);
            }

            query = query.OrderByDescending(c => c.Nascimento).Where(c => c.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Aluno[]> GetAllAlunoAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos.Include(c => c.Cursos).Include(c=> c.RedesSociais);
            if (includeProfessor)
            {
                query = query.Include(pr => pr.ProfessoresCursos).ThenInclude(p => p.Professor);
            }

            query = query.OrderByDescending(c => c.Nascimento);

            return await query.ToArrayAsync();
        }        

        public async Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeCursos)
        {
            IQueryable<Aluno> query = _context.Alunos.Include(c => c.Cursos).Include(c => c.RedesSociais);
            if (includeCursos)
            {
                query = query.Include(pr => pr.ProfessoresCursos).ThenInclude(p => p.Professor);
            }

            query = query.OrderByDescending(c => c.Nascimento).Where(c => c.Id == AlunoId);

            return await query.FirstOrDefaultAsync();
        }

        //CURSO
        public async Task<Professor[]> GetAllProfessoresAsyncByName(string nome, bool includeCursos = false)
        {
            IQueryable<Professor> query = _context.Professores.Include(c => c.RedesSociais);
            if (includeCursos)
            {
                query = query.Include(pr => pr.ProfessoresCursos).ThenInclude(p => p.Curso);
            }

            query = query.OrderBy(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetAllProfessoresAsync(int ProfessorId, bool includeCursos = false)
        {
            IQueryable<Professor> query = _context.Professores.Include(c => c.RedesSociais);
            if (includeCursos)
            {
                query = query.Include(pr => pr.ProfessoresCursos).ThenInclude(p => p.Curso);
            }

            query = query.OrderBy(p => p.Nome).Where(p => p.Id == ProfessorId);

            return await query.FirstOrDefaultAsync();
        }

    }
}
