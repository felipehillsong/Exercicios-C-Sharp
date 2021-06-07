using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Models;
using ProAgil.Repository.Data;
using ProAgil.Repository.IRepository;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        private readonly IProAgilRepository _repo;

        public PalestranteController(IProAgilRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Palestrante/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _repo.GetPalestranteAsync(id, true);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");

            }

        }

        // GET: api/Palestrante
        [HttpGet("getByName/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var results = await _repo.GetAllPalestranteAsyncByName(name, true);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");

            }
        }

        // POST: api/Palestrante
        [HttpPost]
        public async Task<IActionResult> Post(Palestrante palestrante)
        {
            try
            {
                _repo.Insert(palestrante);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{palestrante.Id}", palestrante);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }

            return BadRequest();
        }

        // PUT: api/Palestrante/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Palestrante palestrante)
        {
            try
            {
                var result = await _repo.GetPalestranteAsync(id, false);

                if (result == null)
                {
                    return NotFound();
                }

                _repo.Update(palestrante);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/palestrante/{palestrante.Id}", palestrante);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }

            return BadRequest();
        }        

        // DELETE: api/Palestrante/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _repo.GetPalestranteAsync(id, false);

                if (result == null)
                {
                    return NotFound();
                }

                _repo.Delete(result);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }

            return BadRequest();
        }
    }
}
