using Microsoft.EntityFrameworkCore;
using RetaguardaESilva.Domain.Enumeradores;
using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Persistence.Data;
using RetaguardaESilva.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetaguardaESilva.Domain.ViewModels;
using RetaguardaESilva.Persistence.Migrations;
using System.Runtime.ConstrainedExecution;

namespace RetaguardaESilva.Persistence.Persistencias
{
    public class RelatorioPersist : IRelatorioPersist
    {
        private readonly RetaguardaESilvaContext _context;
        public RelatorioPersist(RetaguardaESilvaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> GetAllClientesAtivosInativosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Cliente.AsNoTracking().Where(c => c.EmpresaId == empresaId && c.DataCadastroCliente >= dataInicio && c.DataCadastroCliente <= dataFinal).OrderBy(c => c.Nome).ToListAsync();
        }
        public async Task<IEnumerable<Cliente>> GetAllClientesAtivosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Cliente.AsNoTracking().Where(c => c.EmpresaId == empresaId && c.DataCadastroCliente >= dataInicio && c.DataCadastroCliente <= dataFinal && c.Ativo == Convert.ToBoolean(Situacao.Ativo)).OrderBy(c => c.Nome).ToListAsync();
        }
        public async Task<IEnumerable<Cliente>> GetAllClientesInativosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Cliente.AsNoTracking().Where(c => c.EmpresaId == empresaId && c.DataCadastroCliente >= dataInicio && c.DataCadastroCliente <= dataFinal && c.Ativo == Convert.ToBoolean(Situacao.Inativo)).OrderBy(c => c.Nome).ToListAsync();
        }
        public async Task<IEnumerable<Cliente>> GetAllClientesExcluidosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Cliente.AsNoTracking().Where(c => c.EmpresaId == empresaId && c.DataCadastroCliente >= dataInicio && c.DataCadastroCliente <= dataFinal && c.StatusExclusao == Convert.ToBoolean(Situacao.Excluido)).OrderBy(c => c.Nome).ToListAsync();
        }
        public async Task<IEnumerable<Fornecedor>> GetAllFornecedoresAtivosInativosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Fornecedor.AsNoTracking().Where(f => f.EmpresaId == empresaId && f.DataCadastroFornecedor >= dataInicio && f.DataCadastroFornecedor <= dataFinal).OrderBy(f => f.Nome).ToListAsync();
        }
        public async Task<IEnumerable<Fornecedor>> GetAllFornecedoresAtivosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Fornecedor.AsNoTracking().Where(f => f.EmpresaId == empresaId && f.DataCadastroFornecedor >= dataInicio && f.DataCadastroFornecedor <= dataFinal && f.Ativo == Convert.ToBoolean(Situacao.Ativo)).OrderBy(f => f.Nome).ToListAsync();
        }
        public async Task<IEnumerable<Fornecedor>> GetAllFornecedoresInativosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Fornecedor.AsNoTracking().Where(f => f.EmpresaId == empresaId && f.DataCadastroFornecedor >= dataInicio && f.DataCadastroFornecedor <= dataFinal && f.Ativo == Convert.ToBoolean(Situacao.Inativo)).OrderBy(f => f.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Fornecedor>> GetAllFornecedoresExcluidosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Fornecedor.AsNoTracking().Where(f => f.EmpresaId == empresaId && f.DataCadastroFornecedor >= dataInicio && f.DataCadastroFornecedor <= dataFinal && f.StatusExclusao == Convert.ToBoolean(Situacao.Excluido)).OrderBy(f => f.Nome).ToListAsync();
        }
        public async Task<IEnumerable<FornecedorProdutoViewModel>> GetFornecedoresProdutosAllAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {   
            var fornecedorProduto = new FornecedorProdutoViewModel();
            var fornecedorProdutoRetorno = new List<FornecedorProdutoViewModel>();
            fornecedorProduto.Produtos = new List<ProdutoFornecedorViewModel>();
            var fornecedores = GetAllFornecedoresAtivosInativosAsync(empresaId, dataInicio, dataFinal);
            foreach (var item in fornecedores.Result)
            {
                int fornecedorId = item.Id;

                fornecedorProduto.Id = item.Id;
                fornecedorProduto.Nome = item.Nome;
                fornecedorProduto.Endereco = item.Endereco;
                fornecedorProduto.Bairro = item.Bairro;
                fornecedorProduto.Numero = item.Numero;
                fornecedorProduto.Municipio = item.Municipio;
                fornecedorProduto.UF = item.UF;
                fornecedorProduto.Pais = item.Pais;
                fornecedorProduto.CEP = item.CEP;
                fornecedorProduto.Complemento = item.Complemento;
                fornecedorProduto.Telefone = item.Telefone;
                fornecedorProduto.Email = item.Email;
                fornecedorProduto.CNPJ = item.CNPJ;
                fornecedorProduto.InscricaoMunicipal = item.InscricaoMunicipal;
                fornecedorProduto.InscricaoEstadual = item.InscricaoEstadual;
                fornecedorProduto.DataCadastroFornecedor = item.DataCadastroFornecedor;
                fornecedorProduto.Ativo = item.Ativo;
                fornecedorProduto.StatusExclusao = item.StatusExclusao;
                fornecedorProduto.EmpresaId = item.EmpresaId;                

                var produtos = await _context.Produto.AsNoTracking().Where(p => p.EmpresaId == empresaId && p.FornecedorId == item.Id).OrderBy(p => p.Nome).ToListAsync();
                foreach (var item2 in produtos)
                {
                    var produto = new ProdutoFornecedorViewModel
                    {
                        Id = item2.Id,
                        Nome = item2.Nome,
                        Quantidade = item2.Quantidade,
                        Ativo = item2.Ativo,
                        StatusExclusao = item2.StatusExclusao,
                        PrecoCompra = item2.PrecoCompra,
                        PrecoVenda = item2.PrecoVenda,
                        Codigo = item2.Codigo,
                        DataCadastroProduto = item2.DataCadastroProduto,
                        EmpresaId = item2.EmpresaId,
                        FornecedorId = item2.FornecedorId
                    };

                    if (item.Id == fornecedorId)
                    {
                        fornecedorProduto.Produtos.Add(produto);
                    }
                }

                fornecedorProdutoRetorno.Add(fornecedorProduto);
            }
            return fornecedorProdutoRetorno;
        }

        public Task<IEnumerable<FornecedorProdutoViewModel>> GetFornecedoresProdutosAtivoAsync(int empresaId, DateTime dataIncio, DateTime dataFinal)
        {
            throw new NotImplementedException();
        }     

        public Task<IEnumerable<FornecedorProdutoViewModel>> GetFornecedoresProdutosInativoAsync(int empresaId, DateTime dataIncio, DateTime dataFinal)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FornecedorProdutoViewModel>> GetFornecedoresProdutosExcluidoAsync(int empresaId, DateTime dataIncio, DateTime dataFinal)
        {
            throw new NotImplementedException();
        }
    }
}
