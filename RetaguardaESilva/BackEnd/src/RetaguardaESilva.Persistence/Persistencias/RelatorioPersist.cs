﻿using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Cliente>> GetAllClientesAtivosInativosExcluidosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Cliente.AsNoTracking().Where(c => c.EmpresaId == empresaId && c.DataCadastroCliente >= dataInicio && c.DataCadastroCliente <= dataFinal).OrderBy(c => c.Nome).ToListAsync();
        }
        public async Task<IEnumerable<Cliente>> GetAllClientesAtivosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Cliente.AsNoTracking().Where(c => c.EmpresaId == empresaId && c.DataCadastroCliente >= dataInicio && c.DataCadastroCliente <= dataFinal && c.Ativo == Convert.ToBoolean(Situacao.Ativo)).OrderBy(c => c.Nome).ToListAsync();
        }
        public async Task<IEnumerable<Cliente>> GetAllClientesInativosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Cliente.AsNoTracking().Where(c => c.EmpresaId == empresaId && c.DataCadastroCliente >= dataInicio && c.DataCadastroCliente <= dataFinal && c.Ativo == Convert.ToBoolean(Situacao.Inativo) && c.StatusExclusao != Convert.ToBoolean(Situacao.Excluido)).OrderBy(c => c.Nome).ToListAsync();
        }
        public async Task<IEnumerable<Cliente>> GetAllClientesExcluidosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Cliente.AsNoTracking().Where(c => c.EmpresaId == empresaId && c.DataCadastroCliente >= dataInicio && c.DataCadastroCliente <= dataFinal && c.StatusExclusao == Convert.ToBoolean(Situacao.Excluido)).OrderBy(c => c.Nome).ToListAsync();
        }
        public async Task<IEnumerable<Fornecedor>> GetAllFornecedoresAtivosInativosExcluidosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Fornecedor.AsNoTracking().Where(f => f.EmpresaId == empresaId && f.DataCadastroFornecedor >= dataInicio && f.DataCadastroFornecedor <= dataFinal).OrderBy(f => f.Nome).ToListAsync();
        }
        public async Task<IEnumerable<Fornecedor>> GetAllFornecedoresAtivosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Fornecedor.AsNoTracking().Where(f => f.EmpresaId == empresaId && f.DataCadastroFornecedor >= dataInicio && f.DataCadastroFornecedor <= dataFinal && f.Ativo == Convert.ToBoolean(Situacao.Ativo)).OrderBy(f => f.Nome).ToListAsync();
        }
        public async Task<IEnumerable<Fornecedor>> GetAllFornecedoresInativosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Fornecedor.AsNoTracking().Where(f => f.EmpresaId == empresaId && f.DataCadastroFornecedor >= dataInicio && f.DataCadastroFornecedor <= dataFinal && f.Ativo == Convert.ToBoolean(Situacao.Inativo) && f.StatusExclusao != Convert.ToBoolean(Situacao.Excluido)).OrderBy(f => f.Nome).ToListAsync();
        }
        public async Task<IEnumerable<Fornecedor>> GetAllFornecedoresExcluidosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal)
        {
            return await _context.Fornecedor.AsNoTracking().Where(f => f.EmpresaId == empresaId && f.DataCadastroFornecedor >= dataInicio && f.DataCadastroFornecedor <= dataFinal && f.StatusExclusao == Convert.ToBoolean(Situacao.Excluido)).OrderBy(f => f.Nome).ToListAsync();
        }
        public async Task<IEnumerable<FornecedorProdutoViewModel>> GetFornecedoresProdutosAllAsync(int empresaId)
        {   
            var fornecedorProdutoRetorno = new List<FornecedorProdutoViewModel>();
            var produtosFornecedor = new List<ProdutoViewModel>();
            var fornecedores = await _context.Fornecedor.AsNoTracking().Where(f => f.EmpresaId == empresaId).OrderBy(f => f.Nome).ToListAsync();
            foreach (var item in fornecedores)
            {
                var fornecedorProduto = new FornecedorProdutoViewModel
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Endereco = item.Endereco,
                    Bairro = item.Bairro,
                    Numero = item.Numero,
                    Municipio = item.Municipio,
                    UF = item.UF,
                    Pais = item.Pais,
                    CEP = item.CEP,
                    Complemento = item.Complemento,
                    Telefone = item.Telefone,
                    Email = item.Email,
                    CNPJ = item.CNPJ,
                    InscricaoMunicipal = item.InscricaoMunicipal,
                    InscricaoEstadual = item.InscricaoEstadual,
                    DataCadastroFornecedor = item.DataCadastroFornecedor,
                    Ativo = item.Ativo,
                    StatusExclusao = item.StatusExclusao,
                    EmpresaId = item.EmpresaId
                };

                fornecedorProdutoRetorno.Add(fornecedorProduto);
            }

            foreach (var item in fornecedorProdutoRetorno)
            {
                var produtos = await _context.Produto.AsNoTracking().Where(p => p.EmpresaId == empresaId && p.FornecedorId == item.Id).OrderBy(p => p.Nome).ToListAsync();
                foreach (var item1 in produtos)
                {
                    var produto = new ProdutoViewModel
                    {
                        Id = item1.Id,
                        Nome = item1.Nome,
                        Quantidade = item1.Quantidade,
                        Ativo = item1.Ativo,
                        StatusExclusao = item1.StatusExclusao,
                        PrecoCompra = item1.PrecoCompra,
                        PrecoVenda = item1.PrecoVenda,
                        Codigo = item1.Codigo,
                        DataCadastroProduto = item1.DataCadastroProduto,
                        EmpresaId = item1.EmpresaId,
                        FornecedorId = item1.FornecedorId
                    };
                    produtosFornecedor.Add(produto);
                }
            }

            foreach (var item in fornecedorProdutoRetorno)
            {
                var produtos = produtosFornecedor.Where(p => p.FornecedorId == item.Id).ToList();
                item.Produtos = produtos;
            }

            foreach (var item in fornecedorProdutoRetorno.ToList())
            {
                if (item.Produtos.Count() == (int)ZerarIdFornecedor.FornecedorSemProduto)
                {
                    fornecedorProdutoRetorno.Remove(item);
                }
            }

            return fornecedorProdutoRetorno;
        }

        public async Task<IEnumerable<FornecedorProdutoViewModel>> GetFornecedoresProdutosAtivoAsync(int empresaId)
        {
            var fornecedorProdutoRetorno = new List<FornecedorProdutoViewModel>();
            var produtosFornecedor = new List<ProdutoViewModel>();
            var fornecedores = await _context.Fornecedor.AsNoTracking().Where(f => f.EmpresaId == empresaId && f.Ativo == Convert.ToBoolean(Situacao.Ativo)).OrderBy(f => f.Nome).ToListAsync();
            foreach (var item in fornecedores)
            {
                var fornecedorProduto = new FornecedorProdutoViewModel
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Endereco = item.Endereco,
                    Bairro = item.Bairro,
                    Numero = item.Numero,
                    Municipio = item.Municipio,
                    UF = item.UF,
                    Pais = item.Pais,
                    CEP = item.CEP,
                    Complemento = item.Complemento,
                    Telefone = item.Telefone,
                    Email = item.Email,
                    CNPJ = item.CNPJ,
                    InscricaoMunicipal = item.InscricaoMunicipal,
                    InscricaoEstadual = item.InscricaoEstadual,
                    DataCadastroFornecedor = item.DataCadastroFornecedor,
                    Ativo = item.Ativo,
                    StatusExclusao = item.StatusExclusao,
                    EmpresaId = item.EmpresaId
                };

                fornecedorProdutoRetorno.Add(fornecedorProduto);
            }

            foreach (var item in fornecedorProdutoRetorno)
            {
                var produtos = await _context.Produto.AsNoTracking().Where(p => p.EmpresaId == empresaId && p.FornecedorId == item.Id && p.Ativo == Convert.ToBoolean(Situacao.Ativo)).OrderBy(p => p.Nome).ToListAsync();
                foreach (var item1 in produtos)
                {
                    var produto = new ProdutoViewModel
                    {
                        Id = item1.Id,
                        Nome = item1.Nome,
                        Quantidade = item1.Quantidade,
                        Ativo = item1.Ativo,
                        StatusExclusao = item1.StatusExclusao,
                        PrecoCompra = item1.PrecoCompra,
                        PrecoVenda = item1.PrecoVenda,
                        Codigo = item1.Codigo,
                        DataCadastroProduto = item1.DataCadastroProduto,
                        EmpresaId = item1.EmpresaId,
                        FornecedorId = item1.FornecedorId
                    };
                    produtosFornecedor.Add(produto);
                }
            }

            foreach (var item in fornecedorProdutoRetorno)
            {
                var produtos = produtosFornecedor.Where(p => p.FornecedorId == item.Id).ToList();
                item.Produtos = produtos;
            }

            foreach (var item in fornecedorProdutoRetorno.ToList())
            {
                if (item.Produtos.Count() == (int)ZerarIdFornecedor.FornecedorSemProduto)
                {
                    fornecedorProdutoRetorno.Remove(item);
                }
            }

            return fornecedorProdutoRetorno;
        }     

        public async Task<IEnumerable<FornecedorProdutoViewModel>> GetFornecedoresProdutosInativoAsync(int empresaId)
        {
            var fornecedorProdutoRetorno = new List<FornecedorProdutoViewModel>();
            var produtosFornecedor = new List<ProdutoViewModel>();
            var fornecedores = await _context.Fornecedor.AsNoTracking().Where(f => f.EmpresaId == empresaId && f.Ativo == Convert.ToBoolean(Situacao.Ativo)).OrderBy(f => f.Nome).ToListAsync();
            foreach (var item in fornecedores)
            {
                var fornecedorProduto = new FornecedorProdutoViewModel
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Endereco = item.Endereco,
                    Bairro = item.Bairro,
                    Numero = item.Numero,
                    Municipio = item.Municipio,
                    UF = item.UF,
                    Pais = item.Pais,
                    CEP = item.CEP,
                    Complemento = item.Complemento,
                    Telefone = item.Telefone,
                    Email = item.Email,
                    CNPJ = item.CNPJ,
                    InscricaoMunicipal = item.InscricaoMunicipal,
                    InscricaoEstadual = item.InscricaoEstadual,
                    DataCadastroFornecedor = item.DataCadastroFornecedor,
                    Ativo = item.Ativo,
                    StatusExclusao = item.StatusExclusao,
                    EmpresaId = item.EmpresaId
                };

                fornecedorProdutoRetorno.Add(fornecedorProduto);
            }

            foreach (var item in fornecedorProdutoRetorno)
            {
                var produtos = await _context.Produto.AsNoTracking().Where(p => p.EmpresaId == empresaId && p.FornecedorId == item.Id && p.Ativo == Convert.ToBoolean(Situacao.Inativo)).OrderBy(p => p.Nome).ToListAsync();
                foreach (var item1 in produtos)
                {
                    var produto = new ProdutoViewModel
                    {
                        Id = item1.Id,
                        Nome = item1.Nome,
                        Quantidade = item1.Quantidade,
                        Ativo = item1.Ativo,
                        StatusExclusao = item1.StatusExclusao,
                        PrecoCompra = item1.PrecoCompra,
                        PrecoVenda = item1.PrecoVenda,
                        Codigo = item1.Codigo,
                        DataCadastroProduto = item1.DataCadastroProduto,
                        EmpresaId = item1.EmpresaId,
                        FornecedorId = item1.FornecedorId
                    };
                    produtosFornecedor.Add(produto);
                }
            }

            foreach (var item in fornecedorProdutoRetorno)
            {
                var produtos = produtosFornecedor.Where(p => p.FornecedorId == item.Id).ToList();
                item.Produtos = produtos;
            }

            foreach (var item in fornecedorProdutoRetorno.ToList())
            {
                if (item.Produtos.Count() == (int)ZerarIdFornecedor.FornecedorSemProduto)
                {
                    fornecedorProdutoRetorno.Remove(item);
                }
            }

            return fornecedorProdutoRetorno;
        }

        public async Task<IEnumerable<FornecedorProdutoViewModel>> GetFornecedoresProdutosExcluidoAsync(int empresaId)
        {
            var fornecedorProdutoRetorno = new List<FornecedorProdutoViewModel>();
            var produtosFornecedor = new List<ProdutoViewModel>();
            var fornecedores = await _context.Fornecedor.AsNoTracking().Where(f => f.EmpresaId == empresaId && f.Ativo == Convert.ToBoolean(Situacao.Ativo)).OrderBy(f => f.Nome).ToListAsync();
            foreach (var item in fornecedores)
            {
                var fornecedorProduto = new FornecedorProdutoViewModel
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Endereco = item.Endereco,
                    Bairro = item.Bairro,
                    Numero = item.Numero,
                    Municipio = item.Municipio,
                    UF = item.UF,
                    Pais = item.Pais,
                    CEP = item.CEP,
                    Complemento = item.Complemento,
                    Telefone = item.Telefone,
                    Email = item.Email,
                    CNPJ = item.CNPJ,
                    InscricaoMunicipal = item.InscricaoMunicipal,
                    InscricaoEstadual = item.InscricaoEstadual,
                    DataCadastroFornecedor = item.DataCadastroFornecedor,
                    Ativo = item.Ativo,
                    StatusExclusao = item.StatusExclusao,
                    EmpresaId = item.EmpresaId
                };

                fornecedorProdutoRetorno.Add(fornecedorProduto);
            }

            foreach (var item in fornecedorProdutoRetorno)
            {
                var produtos = await _context.Produto.AsNoTracking().Where(p => p.EmpresaId == empresaId && p.FornecedorId == item.Id && p.Ativo == Convert.ToBoolean(Situacao.Excluido)).OrderBy(p => p.Nome).ToListAsync();
                foreach (var item1 in produtos)
                {
                    var produto = new ProdutoViewModel
                    {
                        Id = item1.Id,
                        Nome = item1.Nome,
                        Quantidade = item1.Quantidade,
                        Ativo = item1.Ativo,
                        StatusExclusao = item1.StatusExclusao,
                        PrecoCompra = item1.PrecoCompra,
                        PrecoVenda = item1.PrecoVenda,
                        Codigo = item1.Codigo,
                        DataCadastroProduto = item1.DataCadastroProduto,
                        EmpresaId = item1.EmpresaId,
                        FornecedorId = item1.FornecedorId
                    };
                    produtosFornecedor.Add(produto);
                }
            }

            foreach (var item in fornecedorProdutoRetorno)
            {
                var produtos = produtosFornecedor.Where(p => p.FornecedorId == item.Id).ToList();
                item.Produtos = produtos;
            }

            foreach (var item in fornecedorProdutoRetorno.ToList())
            {
                if (item.Produtos.Count() == (int)ZerarIdFornecedor.FornecedorSemProduto)
                {
                    fornecedorProdutoRetorno.Remove(item);
                }
            }

            return fornecedorProdutoRetorno;
        }
    }
}
