using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoCursos.Repository.Data;
using ProjetoCursos.Domain.Models;
using ProjetoCursos.Repository.Repositorio;

namespace ProjetoCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {  
        private readonly IProjetoCursosRepository _repo;

        public AlunoController(IProjetoCursosRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Aluno
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {   
                var results = await _repo.GetAllAlunoAsync(true);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou!");
            }
            
        }

        // POST: api/Aluno
        [HttpPost]
        public async Task<IActionResult> Post(Aluno Aluno)
        {
            try
            {
                _repo.Add(Aluno);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/aluno/{Aluno.Id}", Aluno);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou!");
            }

            return BadRequest();
        }
           
        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno Aluno)
        {
            if (id != Aluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(Aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }       

        // DELETE: api/Aluno/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
