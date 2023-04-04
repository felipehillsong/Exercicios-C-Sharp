using AutoMapper;
using Newtonsoft.Json;
using RetaguardaESilva.Application.ContratosServices;
using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Application.Helpers;
using RetaguardaESilva.Domain.Enumeradores;
using RetaguardaESilva.Domain.Mensagem;
using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Domain.ViewModels;
using RetaguardaESilva.Persistence.Contratos;
using RetaguardaESilva.Persistence.Persistencias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.PersistenciaService
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IValidacoesPersist _validacoesPersist;
        private readonly INotaFiscalPersist _notaFiscalPersist;
        private readonly IPedidoPersist _pedidoPersist;
        private readonly IPedidoNotaPersist _pedidoNotaPersist;
        private readonly IMapper _mapper;

        public NotaFiscalService(IGeralPersist geralPersist, INotaFiscalPersist notaFiscalPersist, IValidacoesPersist validacoesPersist, IPedidoPersist pedidoPersist, IPedidoNotaPersist pedidoNotaPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _notaFiscalPersist = notaFiscalPersist;
            _pedidoPersist = pedidoPersist;
            _pedidoNotaPersist = pedidoNotaPersist;
            _mapper = mapper;
        }

        public async Task<NotaFiscalDTO> AddNotaFiscal(NotaFiscalDTO model)
        {
            try
            {
                var pedido = await _pedidoPersist.GetPedidoByIdAsync(model.EmpresaId, model.PedidoId);
                if (pedido == null)
                {
                    throw new Exception(MensagemDeErro.PedidoNaoEncontrado);
                }
                else
                {
                    var pedidoNota = _pedidoNotaPersist.GetAllPedidosNotaAsync(model.EmpresaId, model.PedidoId);
                    foreach (var item in pedidoNota.Result)
                    {
                        var produto = _validacoesPersist.AtualizarQuantidadeProdutoPosPedido(model.PedidoId, model.EmpresaId, item.ProdutoId, item.Quantidade, out Estoque estoque, out string mensagem);
                        if (produto == null || estoque == null)
                        {
                            throw new Exception(mensagem);
                        }
                        else
                        {
                            _geralPersist.Update<Produto>(produto);
                            await _geralPersist.SaveChangesAsync();
                            _geralPersist.Update<Estoque>(estoque);
                            await _geralPersist.SaveChangesAsync();
                        }
                    }

                    model.Status = (int)StatusNotaFiscal.NotaFiscalAprovada;
                    var notaFiscalDTO = _mapper.Map<NotaFiscal>(model);
                    _geralPersist.Add<NotaFiscal>(notaFiscalDTO);
                    if (await _geralPersist.SaveChangesAsync())
                    {
                        var notaFiscal = await _notaFiscalPersist.GetNotaFiscalByIdAsync(notaFiscalDTO.EmpresaId, notaFiscalDTO.Id);
                        var resultadoNotaFiscal = _mapper.Map<NotaFiscalDTO>(notaFiscal);
                        return resultadoNotaFiscal;
                    }
                    else
                    {
                        throw new Exception(MensagemDeErro.ErroAoCadastrarNotaFiscal);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NotaFiscalDTO> UpdateNotaFiscal(NotaFiscalDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NotaFiscalDTO>> GetAllNotaFiscalAsync(int empresaId)
        {
            try
            {
                var notasFiscais = await _notaFiscalPersist.GetAllNotaFiscalAsync(empresaId);
                if (notasFiscais == null)
                {
                    throw new Exception(MensagemDeErro.NotaFiscalNaoEncontrada);
                }
                else if (notasFiscais.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.NotaFiscalNaoEncontradoEmpresa);
                }
                else
                {
                    var resultadoNotaFiscal = _mapper.Map<IEnumerable<NotaFiscalDTO>>(notasFiscais);
                    return resultadoNotaFiscal;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NotaFiscalDTO> GetNotaFiscalByIdAsync(int empresaId, int clienteId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCliente(int empresaId, int notafiscalId)
        {
            throw new NotImplementedException();
        }
    }
}
