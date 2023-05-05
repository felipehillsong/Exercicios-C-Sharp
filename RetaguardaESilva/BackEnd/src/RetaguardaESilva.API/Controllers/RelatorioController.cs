using Microsoft.AspNetCore.Mvc;
using RetaguardaESilva.Application.ContratosServices;
using RetaguardaESilva.Application.Enumeradores;

namespace RetaguardaESilva.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatorioController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }
        // GET: api/Relatorio
        [HttpGet]
        public async Task<ActionResult> GetRelatorio(int empresaId, int codigoRelatorio)
        {
            try
            {   
                switch (codigoRelatorio)
                {
                    case (int)TipoRelatorio.TodosClientesAtivosInativosExcluidos:
                    var todosClientesAtivosInativos = await _relatorioService.GetClientesAllAsync(empresaId);
                        if (todosClientesAtivosInativos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosClientesAtivosInativos);
                    case (int)TipoRelatorio.TodosClientesAtivos:
                        var todosClientesAtivos = await _relatorioService.GetClientesAtivoAsync(empresaId);
                        if (todosClientesAtivos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosClientesAtivos);
                    case (int)TipoRelatorio.TodosClientesInativos:
                        var todosClientesInativos = await _relatorioService.GetClientesInativoAsync(empresaId);
                        if (todosClientesInativos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosClientesInativos);
                    case (int)TipoRelatorio.TodosClientesExcluidos:
                        var todosClientesExcluidos = await _relatorioService.GetClientesExcluidoAsync(empresaId);
                        if (todosClientesExcluidos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosClientesExcluidos);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }
    }
}
