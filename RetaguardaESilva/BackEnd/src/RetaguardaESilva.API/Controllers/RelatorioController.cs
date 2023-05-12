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
                    case (int)TipoRelatorio.TodosFornecedoresAtivosProdutosAtivoInativoExcluidos:
                        var todosFornecedoresProdutosAtivoInativoExcluidos = await _relatorioService.GetFornecedoresProdutosAllAsync(empresaId);
                        if (todosFornecedoresProdutosAtivoInativoExcluidos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresProdutosAtivoInativoExcluidos);
                    case (int)TipoRelatorio.TodosFornecedoresAtivosProdutosAtivos:
                        var todosFornecedoresProdutosAtivos = await _relatorioService.GetFornecedoresProdutosAtivoAsync(empresaId);
                        if (todosFornecedoresProdutosAtivos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresProdutosAtivos);
                    case (int)TipoRelatorio.TodosFornecedoresAtivosProdutosInativos:
                        var todosFornecedoresProdutosInativos = await _relatorioService.GetFornecedoresProdutosInativoAsync(empresaId);
                        if (todosFornecedoresProdutosInativos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresProdutosInativos);
                    case (int)TipoRelatorio.TodosFornecedoresAtivosProdutosExcluidos:
                        var todosFornecedoresProdutosExcluidos = await _relatorioService.GetFornecedoresProdutosExcluidoAsync(empresaId);
                        if (todosFornecedoresProdutosExcluidos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresProdutosExcluidos);
                    case (int)TipoRelatorio.TodosFornecedoresInativosProdutosAtivoInativoExcluidos:
                        var todosFornecedoresInativosProdutosInativosInativoExcluidos = await _relatorioService.GetFornecedoresInativosProdutosAllAsync(empresaId);
                        if (todosFornecedoresInativosProdutosInativosInativoExcluidos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresInativosProdutosInativosInativoExcluidos);
                    case (int)TipoRelatorio.TodosFornecedoresInativosProdutosAtivos:
                        var todosFornecedoresInativosProdutosAtivos = await _relatorioService.GetFornecedoresInativosProdutosAtivoAsync(empresaId);
                        if (todosFornecedoresInativosProdutosAtivos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresInativosProdutosAtivos);
                    case (int)TipoRelatorio.TodosFornecedoresInativosProdutosInativos:
                        var todosFornecedoresInativosProdutosInativos = await _relatorioService.GetFornecedoresInativosProdutosInativoAsync(empresaId);
                        if (todosFornecedoresInativosProdutosInativos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresInativosProdutosInativos);
                    case (int)TipoRelatorio.TodosFornecedoresInativosProdutosExcluidos:
                        var todosFornecedoresInativosProdutosExcluidos = await _relatorioService.GetFornecedoresInativosProdutosExcluidoAsync(empresaId);
                        if (todosFornecedoresInativosProdutosExcluidos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresInativosProdutosExcluidos);
                    case (int)TipoRelatorio.TodosFornecedoresExcluidosProdutosAtivoInativoExcluidos:
                        var todosFornecedoresExcluidosProdutosInativosInativoExcluidos = await _relatorioService.GetFornecedoresExcluidosProdutosAllAsync(empresaId);
                        if (todosFornecedoresExcluidosProdutosInativosInativoExcluidos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresExcluidosProdutosInativosInativoExcluidos);
                    case (int)TipoRelatorio.TodosFornecedoresExcluidosProdutosAtivos:
                        var todosFornecedoresExcluidosProdutosAtivos = await _relatorioService.GetFornecedoresExcluidosProdutosAtivoAsync(empresaId);
                        if (todosFornecedoresExcluidosProdutosAtivos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresExcluidosProdutosAtivos);
                    case (int)TipoRelatorio.TodosFornecedoresExcluidosProdutosInativos:
                        var todosFornecedoresExcluidosProdutosInativos = await _relatorioService.GetFornecedoresExcluidosProdutosInativoAsync(empresaId);
                        if (todosFornecedoresExcluidosProdutosInativos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresExcluidosProdutosInativos);
                    case (int)TipoRelatorio.TodosFornecedoresExcluidosProdutosExcluidos:
                        var todosFornecedoresExcluidosProdutosExcluidos = await _relatorioService.GetFornecedoresExcluidosProdutosExcluidoAsync(empresaId);
                        if (todosFornecedoresExcluidosProdutosExcluidos == null)
                        {
                            return NotFound();
                        }
                        return Ok(todosFornecedoresExcluidosProdutosExcluidos);
                    case (int)TipoRelatorio.TodosFuncionariosAtivosInativosExcluidos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosFuncionariosAtivosInativosExcluidos = await _relatorioService.GetFuncionariosAllAsync(empresaId, dataIncio, dataFinal);
                            if (todosFuncionariosAtivosInativosExcluidos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosFuncionariosAtivosInativosExcluidos);
                        }
                    case (int)TipoRelatorio.TodosFuncionariosAtivos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosFuncionariosAtivos = await _relatorioService.GetFuncionariosAtivoAsync(empresaId, dataIncio, dataFinal);
                            if (todosFuncionariosAtivos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosFuncionariosAtivos);
                        }
                    case (int)TipoRelatorio.TodosFuncionariosInativos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosFuncionariosInativos = await _relatorioService.GetFuncionariosInativoAsync(empresaId, dataIncio, dataFinal);
                            if (todosFuncionariosInativos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosFuncionariosInativos);
                        }
                    case (int)TipoRelatorio.TodosFuncionariosExcluidos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosFuncionariosExcluidos = await _relatorioService.GetFuncionariosExcluidoAsync(empresaId, dataIncio, dataFinal);
                            if (todosFuncionariosExcluidos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosFuncionariosExcluidos);
                        }
                    case (int)TipoRelatorio.TodosTransportadoresAtivosInativosExcluidos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosTransportadoresAtivosInativosExcluidos = await _relatorioService.GetTransportadoresAllAsync(empresaId, dataIncio, dataFinal);
                            if (todosTransportadoresAtivosInativosExcluidos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosTransportadoresAtivosInativosExcluidos);
                        }
                    case (int)TipoRelatorio.TodosTransportadoresAtivos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosTransportadoresAtivos = await _relatorioService.GetTransportadoresAtivoAsync(empresaId, dataIncio, dataFinal);
                            if (todosTransportadoresAtivos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosTransportadoresAtivos);
                        }
                    case (int)TipoRelatorio.TodosTransportadoresInativos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosTransportadoresInativos = await _relatorioService.GetTransportadoresInativoAsync(empresaId, dataIncio, dataFinal);
                            if (todosTransportadoresInativos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosTransportadoresInativos);
                        }
                    case (int)TipoRelatorio.TodosTransportadoresExcluidos:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosTransportadoresExcluidos = await _relatorioService.GetTransportadoresExcluidoAsync(empresaId, dataIncio, dataFinal);
                            if (todosTransportadoresExcluidos == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosTransportadoresExcluidos);
                        }
                    case (int)TipoRelatorio.TodosUsuarios:
                        if (dataIncio == null || dataFinal == null)
                        {
                            return NotFound(MensagemDeErro.SemDataRelatorio);
                        }
                        else
                        {
                            var todosUsuarios = await _relatorioService.GetUsuarioAsync(empresaId, dataIncio, dataFinal);
                            if (todosUsuarios == null)
                            {
                                return NotFound();
                            }
                            return Ok(todosUsuarios);
                        }
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
