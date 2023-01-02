using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RetaguardaESilva.Application.ContratosServices;
using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Domain.Mensagem;
using RetaguardaESilva.Persistence.Data;

namespace RetaguardaESilva.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        // GET: api/Estoque
        [HttpGet]
        public async Task<ActionResult> GetEstoque(int empresaId)
        {            
            try
            {
                var estoques = await _estoqueService.GetAllEstoquesAsync(empresaId);
                if (estoques == null)
                {
                    return NotFound();
                }
                return Ok(estoques);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        // GET: api/Estoque/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEstoque(int empresaId, int id)
        {
            try
            {
                var estoque = await _estoqueService.GetEstoqueByIdAsync(empresaId, id);
                if (estoque == null)
                {
                    return NotFound();
                }
                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        // PUT: api/Estoque/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstoque(int empresaId, int id, EstoqueDTO model)
        {
            try
            {
                var estoque = await _estoqueService.UpdateEstoque(empresaId, id, model);
                if (estoque == null)
                {
                    return BadRequest();
                }
                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        // DELETE: api/Estoque/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int empresaId, int id)
        {
            try
            {
                if (await _estoqueService.DeleteEstoque(empresaId, id))
                {
                    return Ok( new { message = MensagemDeSucesso.EstoqueDeletado });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }
    }
}
