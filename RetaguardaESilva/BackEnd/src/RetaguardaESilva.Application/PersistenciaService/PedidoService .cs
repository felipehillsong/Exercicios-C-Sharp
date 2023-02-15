using AutoMapper;
using Newtonsoft.Json;
using RetaguardaESilva.Application.ContratosServices;
using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Application.Helpers;
using RetaguardaESilva.Domain.Enumeradores;
using RetaguardaESilva.Domain.Mensagem;
using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Persistence.Contratos;
using System;
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
        private readonly IMapper _mapper;

        public PedidoService(IGeralPersist geralPersist, IValidacoesPersist validacoesPersist, IPedidoPersist pedidoPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _pedidoPersist = pedidoPersist;
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
                                    DataCadastroPedidoNota = item.DataCadastroProduto,
                                    Status = retornoPedido.Status
                                };
                                var pedidoNotaCreateDTO = _mapper.Map<PedidoNota>(pedidoNotaDTO);
                                _geralPersist.Add<PedidoNota>(pedidoNotaCreateDTO);
                                if (await _geralPersist.SaveChangesAsync())
                                {
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

        public Task<bool> DeletePedido(int empresaId, int pedidoId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PedidoDTO>> GetAllPedidosAsync(int empresaId)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoDTO> GetPedidoByIdAsync(int empresaId, int pedidoId)
        {
            throw new NotImplementedException();
        }
    }
}
