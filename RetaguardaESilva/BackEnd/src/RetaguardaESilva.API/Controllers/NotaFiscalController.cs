using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RetaguardaESilva.Application.ContratosServices;
using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Application.PersistenciaService;
using RetaguardaESilva.Domain.Mensagem;
using RetaguardaESilva.Persistence.Data;

namespace RetaguardaESilva.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly INotaFiscalService _notaFiscalService;

        public NotaFiscalController(INotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }

        // GET: api/NotaFiscal
        [HttpGet]
        public async Task<ActionResult> GetNotaFiscal(int empresaId)
        {
            try
            {
                var notasFiscais = await _notaFiscalService.GetAllNotaFiscalAsync(empresaId);
                if (notasFiscais == null)
                {
                    return NotFound();
                }
                return Ok(notasFiscais);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        // POST: api/NotaFiscal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostNotaFiscal(NotaFiscalDTO model)
        {
            try
            {
                var notaFiscal = await _notaFiscalService.AddNotaFiscal(model);
                if (notaFiscal == null)
                {
                    return BadRequest();
                }
                return Ok(notaFiscal);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        // GET: api/NotaFiscal/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetNotaFiscalPedido(int empresaId, int id)
        {
            try
            {
                var notaPedido = await _notaFiscalService.GetNotaFiscalPedidoByIdAsync(empresaId, id);
                if (notaPedido == null)
                {
                    return NotFound();
                }
                return Ok(notaPedido);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }
    }
}
