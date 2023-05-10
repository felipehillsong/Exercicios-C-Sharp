using Microsoft.AspNetCore.Mvc;
using RetaguardaESilva.Application.ContratosServices;
using RetaguardaESilva.Application.Enumeradores;
using RetaguardaESilva.Domain.Mensagem;

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
        public async Task<ActionResult> GetRelatorio(int empresaId, int codigoRelatorio, string? dataIncio, string? dataFinal)
        {
            try
            {   
                switch (codigoRelatorio)
                {
                    case (int)TipoRelatorio.TodosClientesAtivosInativosExcluidos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosClientesAtivosInativosExcluidos = await _relatorioService.GetClientesAllAsync(empresaId, dataIncio, dataFinal);
                            if (todosClientesAtivosInativosExcluidos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosClientesAtivosInativosExcluidos);
                        }
                    case (int)TipoRelatorio.TodosClientesAtivos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosClientesAtivos = await _relatorioService.GetClientesAtivoAsync(empresaId, dataIncio, dataFinal);
                            if (todosClientesAtivos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosClientesAtivos);
                        }
                    case (int)TipoRelatorio.TodosClientesInativos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosClientesInativos = await _relatorioService.GetClientesInativoAsync(empresaId, dataIncio, dataFinal);
                            if (todosClientesInativos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosClientesInativos);
                        }
                    case (int)TipoRelatorio.TodosClientesExcluidos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosClientesExcluidos = await _relatorioService.GetClientesExcluidoAsync(empresaId, dataIncio, dataFinal);
                            if (todosClientesExcluidos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosClientesExcluidos);
                        }
                    case (int)TipoRelatorio.TodosFornecedoresAtivosInativosExcluidos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosFornecedoresAtivosInativosExcluidos = await _relatorioService.GetFornecedoresAllAsync(empresaId, dataIncio, dataFinal);
                            if (todosFornecedoresAtivosInativosExcluidos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosFornecedoresAtivosInativosExcluidos);
                        }
                    case (int)TipoRelatorio.TodosFornecedoresAtivos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosFornecedoresAtivos = await _relatorioService.GetFornecedoresAtivoAsync(empresaId, dataIncio, dataFinal);
                            if (todosFornecedoresAtivos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosFornecedoresAtivos);
                        }
                    case (int)TipoRelatorio.TodosFornecedoresInativos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosFornecedoresInativos = await _relatorioService.GetFornecedoresInativoAsync(empresaId, dataIncio, dataFinal);
                            if (todosFornecedoresInativos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosFornecedoresInativos);
                        }
                    case (int)TipoRelatorio.TodosFornecedoresExcluidos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosFornecedoresExcluidos = await _relatorioService.GetFornecedoresExcluidoAsync(empresaId, dataIncio, dataFinal);
                            if (todosFornecedoresExcluidos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosFornecedoresExcluidos);
                        }
                    case (int)TipoRelatorio.TodosFornecedoresProdutosAtivoInativoExcluidos:
                        var todosFornecedoresProdutosAtivoInativoExcluidos = await _relatorioService.GetFornecedoresProdutosAllAsync(empresaId);
                        if (todosFornecedoresProdutosAtivoInativoExcluidos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresProdutosAtivoInativoExcluidos);
                    case (int)TipoRelatorio.TodosFornecedoresProdutosAtivos:
                        var todosFornecedoresProdutosAtivos = await _relatorioService.GetFornecedoresProdutosAtivoAsync(empresaId);
                        if (todosFornecedoresProdutosAtivos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresProdutosAtivos);
                    case (int)TipoRelatorio.TodosFornecedoresProdutosInativos:
                        var todosFornecedoresProdutosInativos = await _relatorioService.GetFornecedoresProdutosInativoAsync(empresaId);
                        if (todosFornecedoresProdutosInativos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresProdutosInativos);
                    case (int)TipoRelatorio.TodosFornecedoresProdutosExcluidos:
                        var todosFornecedoresProdutosExcluidos = await _relatorioService.GetFornecedoresProdutosExcluidoAsync(empresaId);
                        if (todosFornecedoresProdutosExcluidos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresProdutosExcluidos);
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
