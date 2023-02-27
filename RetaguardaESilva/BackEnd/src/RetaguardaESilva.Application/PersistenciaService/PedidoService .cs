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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.PersistenciaService
{
    public class PedidoService : IPedidoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IValidacoesPersist _validacoesPersist;
        private readonly IPedidoPersist _pedidoPersist;
        private readonly IClientePersist _clientePersist;
        private readonly IMapper _mapper;

        public PedidoService(IGeralPersist geralPersist, IValidacoesPersist validacoesPersist, IPedidoPersist pedidoPersist, IClientePersist clientePersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _pedidoPersist = pedidoPersist;
            _clientePersist = clientePersist;
            _mapper = mapper;
        }

        public async Task<PedidoCreateDTO> AddPedido(PedidoCreateDTO model)
        {
            try
            {
                model.Status = (int)StatusPedido.PedidoEmAnalise;
                var pedidoDTO = new PedidoDTO()
                {
                    Id = (int)Ids.IdCreate,
                    ClienteId = model.ClienteId,
                    TransportadorId = model.TransportadorId,
                    EmpresaId = model.EmpresaId,
                    UsuarioId = model.UsuarioId,
                    PrecoTotal = model.PrecoTotal,
                    DataCadastroPedido = model.DataCadastroPedido,
                    Status = model.Status
                };

                var pedidoCreateDTO = _mapper.Map<Pedido>(pedidoDTO);
                _geralPersist.Add<Pedido>(pedidoCreateDTO);
                if(await _geralPersist.SaveChangesAsync())
                {
                    var retornoPedido = await _pedidoPersist.GetPedidoByIdAsync(pedidoCreateDTO.EmpresaId, pedidoCreateDTO.Id);
                    if (retornoPedido != null)
                    {
                        List<string> produtosSemEstoque = new List<string>();
                        foreach (var item in model.Produtos)
                        {
                            if (_validacoesPersist.ExisteEstoqueVenda(model.EmpresaId, item.Id))
                            {
                                var pedidoNotaDTO = new PedidoNotaDTO()
                                {
                                    Id = (int)Ids.IdCreate,
                                    PedidoId = retornoPedido.Id,
                                    ClienteId = retornoPedido.ClienteId,
                                    FornecedorId = item.FornecedorId,
                                    ProdutoId = item.Id,
                                    EmpresaId = item.EmpresaId,
                                    TransportadorId = retornoPedido.TransportadorId,
                                    UsuarioId = retornoPedido.UsuarioId,
                                    Quantidade = item.Quantidade,
                                    PrecoVenda = item.PrecoVenda,
                                    PrecoTotal = item.Quantidade * item.PrecoVenda,
                                    DataCadastroPedidoNota = item.DataCadastroProduto,
                                    Status = retornoPedido.Status
                                };
                                var pedidoNotaCreate = _mapper.Map<PedidoNota>(pedidoNotaDTO);
                                _geralPersist.Add<PedidoNota>(pedidoNotaCreate);
                                if (await _geralPersist.SaveChangesAsync())
                                {
                                    var produtoUpdateDTO = _mapper.Map<Produto>(item);
                                    var produtoRetorno = _validacoesPersist.AtualizarQuantidadeProdutoPosPedido(produtoUpdateDTO, out Estoque estoqueUpdate);
                                    _geralPersist.Update<Produto>(produtoRetorno);
                                    await _geralPersist.SaveChangesAsync();
                                    _geralPersist.Update<Estoque>(estoqueUpdate);
                                    await _geralPersist.SaveChangesAsync();
                                    continue;
                                }
                                else
                                {
                                    throw new Exception(MensagemDeErro.ErroAoCadastrarItensPedido);
                                }
                            }
                            else
                            {
                                produtosSemEstoque.Add(_validacoesPersist.RetornarNomeProdutosNaoEncontrados(model.EmpresaId, item.Id));
                            }
                        }
                        var retornoPedidoCompleto = _mapper.Map<PedidoCreateDTO>(retornoPedido);
                        retornoPedidoCompleto.ProdutosSemEstoque = produtosSemEstoque;
                        return retornoPedidoCompleto;
                    }
                }
                throw new Exception(MensagemDeErro.ErroAoCadastrarPedido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 

        public Task<PedidoUpdateDTO> UpdatePedido(PedidoUpdateDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePedido(int empresaId, int pedidoId)
        {
            try
            {
                var pedido = await _pedidoPersist.GetPedidoByIdAsync(empresaId, pedidoId);
                if (pedido == null)
                {
                    throw new Exception(MensagemDeErro.pedidoNaoEncontradoDelete);
                }
                else
                {
                    if(_validacoesPersist.AtualizarQuantidadeProdutoEstoquePosPedido(pedido, out List<Produto> produtos, out List<Estoque> estoques, out List<PedidoNota> pedidosNotas))
                    {
                        foreach (var item in produtos)
                        {
                            _geralPersist.Update<Produto>(item);
                            await _geralPersist.SaveChangesAsync();
                        }
                        foreach (var item in estoques)
                        {
                            _geralPersist.Update<Estoque>(item);
                            await _geralPersist.SaveChangesAsync();
                        }
                        foreach (var item in pedidosNotas)
                        {
                            _geralPersist.Delete(item);
                            await _geralPersist.SaveChangesAsync();
                        }
                        _geralPersist.Delete<Pedido>(pedido);
                        return await _geralPersist.SaveChangesAsync();
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PedidoRetornoDTO>> GetAllPedidosAsync(int empresaId)
        {
            try
            {
                var pedidos = await _pedidoPersist.GetAllPedidosAsync(empresaId);
                if (pedidos == null)
                {
                    throw new Exception(MensagemDeErro.PedidoNaoEncontradoEmpresa);
                }
                else if (pedidos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.PedidoNaoEncontrado);
                }
                else
                {
                    var pedidosViewModel = _mapper.Map<IEnumerable<PedidoViewModel>>(pedidos);
                    var pedidosRetorno = _validacoesPersist.RetornarPedidosView(pedidosViewModel);
                    var resultadoPedidos = _mapper.Map<IEnumerable<PedidoRetornoDTO>>(pedidosRetorno);
                    return resultadoPedidos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<PedidoDTO> GetPedidoByIdAsync(int empresaId, int pedidoId)
        {
            throw new NotImplementedException();
        }
    }
}
