﻿using Microsoft.EntityFrameworkCore;
using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Persistence.Data;
using RetaguardaESilva.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetaguardaESilva.Domain.Enumeradores;
using RetaguardaESilva.Domain.Mensagem;
using System.Text.RegularExpressions;
using ProEventos.Persistence.Persistencias;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using RetaguardaESilva.Domain.ViewModels;

namespace RetaguardaESilva.Persistence.Persistencias
{
    public class ValidacoesPersist : IValidacoesPersist
    {
        private readonly RetaguardaESilvaContext _context;
        public ValidacoesPersist(RetaguardaESilvaContext context)
        {
            _context = context;
        }

        public bool ExisteCliente(int empresaId, string cnpjCpf, string inscricaoMunicipal, string inscricaoEstadual, int clienteId, bool isUpdate, out string mensagem)
        {
            var clienteCpfCnpjRetorno = _context.Cliente.AsNoTracking().FirstOrDefault(c => c.EmpresaId == empresaId && c.CPFCNPJ == cnpjCpf && c.Id != clienteId);
            var clienteImRetorno = _context.Cliente.AsNoTracking().FirstOrDefault(c => c.EmpresaId == empresaId && c.InscricaoMunicipal == inscricaoMunicipal && c.Id != clienteId);
            var clienteIeRetorno = _context.Cliente.AsNoTracking().FirstOrDefault(c => c.EmpresaId == empresaId && c.InscricaoEstadual == inscricaoEstadual && c.Id != clienteId);
            var clienteCpfCnpjImIe = _context.Cliente.AsNoTracking().Where(c => c.EmpresaId == empresaId);

            if (ExisteEmpresaCadastrada(empresaId))
            {
                if (isUpdate)
                {
                    if (clienteId != null || clienteId != 0)
                    {
                        if (clienteCpfCnpjRetorno != null)
                        {
                            mensagem = MensagemDeErro.ClienteJaCadastrado;
                            return true;
                        }
                        else if (clienteImRetorno != null && clienteIeRetorno != null)
                        {
                            if (clienteImRetorno.InscricaoMunicipal == String.Empty && clienteIeRetorno.InscricaoEstadual == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else if (clienteImRetorno.InscricaoMunicipal == null && clienteIeRetorno.InscricaoEstadual == null)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.ClienteJaCadastrado;
                                return true;
                            }
                        }
                        else if (clienteImRetorno == null && clienteIeRetorno == null)
                        {
                            mensagem = MensagemDeSucesso.AtualizarOK;
                            return false;
                        }
                        else if (clienteImRetorno != null)
                        {
                            if (clienteImRetorno.InscricaoMunicipal == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.ClienteJaCadastrado;
                                return true;
                            }
                        }
                        else if (clienteIeRetorno != null)
                        {
                            if (clienteIeRetorno.InscricaoEstadual == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.ClienteJaCadastrado;
                                return true;
                            }
                        }
                        else
                        {
                            mensagem = MensagemDeErro.ClienteJaCadastrado;
                            return true;
                        }
                    }
                    else
                    {
                        mensagem = MensagemDeErro.ClienteSemId;
                        return true;
                    }
                }
                else
                {
                    if (clienteCpfCnpjImIe == null)
                    {
                        mensagem = MensagemDeSucesso.CadastrarOk;
                        return false;
                    }
                    else
                    {
                        if (clienteCpfCnpjRetorno != null)
                        {
                            mensagem = MensagemDeErro.ClienteJaCadastrado;
                            return true;
                        }
                        else if (clienteImRetorno != null && clienteIeRetorno != null)
                        {
                            if (clienteImRetorno.InscricaoMunicipal == String.Empty && clienteIeRetorno.InscricaoEstadual == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.CadastrarOk;
                                return false;
                            }
                            else if (clienteImRetorno.InscricaoMunicipal == null && clienteIeRetorno.InscricaoEstadual == null)
                            {
                                mensagem = MensagemDeSucesso.CadastrarOk;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.ClienteJaCadastrado;
                                return true;
                            }
                        }
                        else if (clienteImRetorno == null && clienteIeRetorno == null)
                        {
                            mensagem = MensagemDeSucesso.CadastrarOk;
                            return false;
                        }
                        else if (clienteImRetorno != null)
                        {
                            if (clienteImRetorno.InscricaoMunicipal == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.CadastrarOk;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.ClienteJaCadastrado;
                                return true;
                            }
                        }
                        else if (clienteIeRetorno != null)
                        {
                            if (clienteIeRetorno.InscricaoEstadual == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.CadastrarOk;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.ClienteJaCadastrado;
                                return true;
                            }
                        }
                        else
                        {
                            mensagem = MensagemDeErro.ClienteJaCadastrado;
                            return true;
                        }
                    }
                }
            }
            else
            {
                mensagem = MensagemDeErro.EmpresaClienteInexistente;
                return true;
            }
        }

        public bool ExisteFornecedor(int empresaId, string cnpj, string inscricaoMunicipal, string inscricaoEstadual, int fornecedorId, bool isUpdate, out string mensagem)
        {
            var fornecedorCpfCnpjRetorno = _context.Fornecedor.AsNoTracking().FirstOrDefault(f => f.EmpresaId == empresaId && f.CNPJ == cnpj && f.Id != fornecedorId);
            var fornecedorImRetorno = _context.Fornecedor.AsNoTracking().FirstOrDefault(f => f.EmpresaId == empresaId && f.InscricaoMunicipal == inscricaoMunicipal && f.Id != fornecedorId);
            var fornecedorIeRetorno = _context.Fornecedor.AsNoTracking().FirstOrDefault(f => f.EmpresaId == empresaId && f.InscricaoEstadual == inscricaoEstadual && f.Id != fornecedorId);
            var fornecedorCpfCnpjImIe = _context.Fornecedor.AsNoTracking().Where(f => f.EmpresaId == empresaId);

            if (ExisteEmpresaCadastrada(empresaId))
            {
                if (isUpdate)
                {
                    if (fornecedorId != null || fornecedorId != 0)
                    {
                        if (fornecedorCpfCnpjRetorno != null)
                        {
                            mensagem = MensagemDeErro.FornecedorJaCadastrado;
                            return true;
                        }
                        else if (fornecedorImRetorno != null && fornecedorIeRetorno != null)
                        {
                            if (fornecedorImRetorno.InscricaoMunicipal == String.Empty && fornecedorIeRetorno.InscricaoEstadual == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.FornecedorJaCadastrado;
                                return true;
                            }
                        }
                        else if (fornecedorImRetorno == null && fornecedorIeRetorno == null)
                        {
                            mensagem = MensagemDeSucesso.AtualizarOK;
                            return false;
                        }
                        else if (fornecedorImRetorno != null)
                        {
                            if (fornecedorImRetorno.InscricaoMunicipal == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.FornecedorJaCadastrado;
                                return true;
                            }
                        }
                        else if (fornecedorIeRetorno != null)
                        {
                            if (fornecedorIeRetorno.InscricaoEstadual == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.FornecedorJaCadastrado;
                                return true;
                            }
                        }
                        else
                        {
                            mensagem = MensagemDeErro.FornecedorJaCadastrado;
                            return true;
                        }
                    }
                    else
                    {
                        mensagem = MensagemDeErro.FornecedorSemId;
                        return true;
                    }
                }
                else
                {
                    if (fornecedorCpfCnpjImIe == null)
                    {
                        mensagem = MensagemDeSucesso.CadastrarOk;
                        return false;
                    }
                    else
                    {
                        if (fornecedorCpfCnpjRetorno != null)
                        {
                            mensagem = MensagemDeErro.FornecedorJaCadastrado;
                            return true;
                        }
                        else if (fornecedorImRetorno != null && fornecedorIeRetorno != null)
                        {
                            if (fornecedorImRetorno.InscricaoMunicipal == String.Empty && fornecedorIeRetorno.InscricaoEstadual == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else if (fornecedorImRetorno.InscricaoMunicipal == null && fornecedorIeRetorno.InscricaoEstadual == null)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.FornecedorJaCadastrado;
                                return true;
                            }
                        }
                        else if (fornecedorImRetorno == null && fornecedorIeRetorno == null)
                        {
                            mensagem = MensagemDeSucesso.AtualizarOK;
                            return false;
                        }
                        else if (fornecedorImRetorno != null)
                        {
                            if (fornecedorImRetorno.InscricaoMunicipal == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.FornecedorJaCadastrado;
                                return true;
                            }
                        }
                        else if (fornecedorIeRetorno != null)
                        {
                            if (fornecedorIeRetorno.InscricaoEstadual == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.FornecedorJaCadastrado;
                                return true;
                            }
                        }
                        else
                        {
                            mensagem = MensagemDeErro.FornecedorJaCadastrado;
                            return true;
                        }
                    }
                }
            }
            else
            {
                mensagem = MensagemDeErro.EmpresaFornecedorInexistente;
                return true;
            }
        }

        public bool ExisteTransportador(int empresaId, string cnpj, string inscricaoMunicipal, string inscricaoEstadual, int transportadorId, bool isUpdate, out string mensagem)
        {
            var transportadorCpfCnpjRetorno = _context.Transportador.AsNoTracking().FirstOrDefault(f => f.EmpresaId == empresaId && f.CNPJ == cnpj && f.Id != transportadorId);
            var transportadorImRetorno = _context.Transportador.AsNoTracking().FirstOrDefault(f => f.EmpresaId == empresaId && f.InscricaoMunicipal == inscricaoMunicipal && f.Id != transportadorId);
            var transportadorIeRetorno = _context.Transportador.AsNoTracking().FirstOrDefault(f => f.EmpresaId == empresaId && f.InscricaoEstadual == inscricaoEstadual && f.Id != transportadorId);
            var transportadorCpfCnpjImIe = _context.Transportador.AsNoTracking().Where(f => f.EmpresaId == empresaId);

            if (ExisteEmpresaCadastrada(empresaId))
            {
                if (isUpdate)
                {
                    if (transportadorId != null || transportadorId != 0)
                    {
                        if (transportadorCpfCnpjRetorno != null)
                        {
                            mensagem = MensagemDeErro.TransportadorJaCadastrado;
                            return true;
                        }
                        else if (transportadorImRetorno != null && transportadorIeRetorno != null)
                        {
                            if (transportadorImRetorno.InscricaoMunicipal == String.Empty && transportadorIeRetorno.InscricaoEstadual == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.TransportadorJaCadastrado;
                                return true;
                            }
                        }
                        else if (transportadorImRetorno == null && transportadorIeRetorno == null)
                        {
                            mensagem = MensagemDeSucesso.AtualizarOK;
                            return false;
                        }
                        else if (transportadorImRetorno != null)
                        {
                            if (transportadorImRetorno.InscricaoMunicipal == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.TransportadorJaCadastrado;
                                return true;
                            }
                        }
                        else if (transportadorIeRetorno != null)
                        {
                            if (transportadorIeRetorno.InscricaoEstadual == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.TransportadorJaCadastrado;
                                return true;
                            }
                        }
                        else
                        {
                            mensagem = MensagemDeErro.TransportadorJaCadastrado;
                            return true;
                        }
                    }
                    else
                    {
                        mensagem = MensagemDeErro.TransportadorSemId;
                        return true;
                    }
                }
                else
                {
                    if (transportadorCpfCnpjImIe == null)
                    {
                        mensagem = MensagemDeSucesso.CadastrarOk;
                        return false;
                    }
                    else
                    {
                        if (transportadorCpfCnpjRetorno != null)
                        {
                            mensagem = MensagemDeErro.TransportadorJaCadastrado;
                            return true;
                        }
                        else if (transportadorImRetorno != null && transportadorIeRetorno != null)
                        {
                            if (transportadorImRetorno.InscricaoMunicipal == String.Empty && transportadorIeRetorno.InscricaoEstadual == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else if (transportadorImRetorno.InscricaoMunicipal == null && transportadorIeRetorno.InscricaoEstadual == null)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.TransportadorJaCadastrado;
                                return true;
                            }
                        }
                        else if (transportadorImRetorno == null && transportadorIeRetorno == null)
                        {
                            mensagem = MensagemDeSucesso.AtualizarOK;
                            return false;
                        }
                        else if (transportadorImRetorno != null)
                        {
                            if (transportadorImRetorno.InscricaoMunicipal == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.TransportadorJaCadastrado;
                                return true;
                            }
                        }
                        else if (transportadorIeRetorno != null)
                        {
                            if (transportadorIeRetorno.InscricaoEstadual == String.Empty)
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                return false;
                            }
                            else
                            {
                                mensagem = MensagemDeErro.TransportadorJaCadastrado;
                                return true;
                            }
                        }
                        else
                        {
                            mensagem = MensagemDeErro.TransportadorJaCadastrado;
                            return true;
                        }
                    }
                }
            }
            else
            {
                mensagem = MensagemDeErro.EmpresaTransportadorInexistente;
                return true;
            }
        }

        public bool ExisteFuncionario(int empresaId, string cpf, int funcionarioId, bool isUpdate, out string mensagem)
        {
            var funcionarioCpfUpdateRetorno = _context.Funcionario.AsNoTracking().FirstOrDefault(f => f.EmpresaId == empresaId && f.CPF == cpf && f.Id != funcionarioId);
            var funcionarioCpfAdd = _context.Funcionario.AsNoTracking().Where(f => f.EmpresaId == empresaId);
            if (ExisteEmpresaCadastrada(empresaId))
            {
                if (isUpdate)
                {
                    if (funcionarioId != null || funcionarioId != 0)
                    {
                        if (funcionarioCpfUpdateRetorno != null)
                        {
                            mensagem = MensagemDeErro.FuncionarioJaCadastrado;
                            return true;
                        }
                        else
                        {
                            mensagem = MensagemDeSucesso.AtualizarOK;
                            return false;
                        }
                    }
                    else
                    {
                        mensagem = MensagemDeErro.FuncionarioSemId;
                        return true;
                    }
                }
                else
                {
                    var funcionarioCpf = funcionarioCpfAdd.FirstOrDefault(f => f.CPF == cpf);
                    if (funcionarioCpf != null)
                    {
                        mensagem = MensagemDeErro.FuncionarioJaCadastrado;
                        return true;
                    }
                    else
                    {
                        mensagem = MensagemDeSucesso.CadastrarOk;
                        return false;
                    }
                }
            }
            else
            {
                mensagem = MensagemDeErro.EmpresaFuncionarioInexistente;
                return true;
            }

        }

        public bool ExisteEmpresa(int empresaId, string cnpj, string inscricaoMunicipal, string inscricaoEstadual, bool isUpdate, out string mensagem)
        {
            var empresaCpfCnpjRetorno = _context.Empresa.AsNoTracking().FirstOrDefault(e => e.CNPJ == cnpj && e.Id != empresaId);
            var empresaImRetorno = _context.Empresa.AsNoTracking().FirstOrDefault(e => e.InscricaoMunicipal == inscricaoMunicipal && e.Id != empresaId);
            var empresaIeRetorno = _context.Empresa.AsNoTracking().FirstOrDefault(e => e.InscricaoEstadual == inscricaoEstadual && e.Id != empresaId);
            var empresaCpfCnpjImIe = _context.Empresa.AsNoTracking().Where(e => e.Id == empresaId);

            if (isUpdate)
            {
                if (empresaId != null || empresaId != 0)
                {
                    if (empresaCpfCnpjRetorno != null)
                    {
                        mensagem = MensagemDeErro.EmpresaJaCadastrada;
                        return true;
                    }
                    else if (empresaImRetorno != null && empresaIeRetorno != null)
                    {
                        if (empresaImRetorno.InscricaoMunicipal == String.Empty && empresaIeRetorno.InscricaoEstadual == String.Empty)
                        {
                            mensagem = MensagemDeSucesso.AtualizarOK;
                            return false;
                        }
                        else
                        {
                            mensagem = MensagemDeErro.EmpresaJaCadastrada;
                            return true;
                        }
                    }
                    else if (empresaImRetorno == null && empresaIeRetorno == null)
                    {
                        mensagem = MensagemDeSucesso.AtualizarOK;
                        return false;
                    }
                    else if (empresaImRetorno != null)
                    {
                        if (empresaImRetorno.InscricaoMunicipal == String.Empty)
                        {
                            mensagem = MensagemDeSucesso.AtualizarOK;
                            return false;
                        }
                        else
                        {
                            mensagem = MensagemDeErro.EmpresaJaCadastrada;
                            return true;
                        }
                    }
                    else if (empresaIeRetorno != null)
                    {
                        if (empresaIeRetorno.InscricaoEstadual == String.Empty)
                        {
                            mensagem = MensagemDeSucesso.AtualizarOK;
                            return false;
                        }
                        else
                        {
                            mensagem = MensagemDeErro.EmpresaJaCadastrada;
                            return true;
                        }
                    }
                    else
                    {
                        mensagem = MensagemDeErro.EmpresaJaCadastrada;
                        return true;
                    }
                }
                else
                {
                    mensagem = MensagemDeErro.EmpresaSemId;
                    return true;
                }
            }
            else
            {
                if (empresaCpfCnpjImIe == null)
                {
                    mensagem = MensagemDeSucesso.CadastrarOk;
                    return false;
                }
                else
                {   
                    if (empresaCpfCnpjRetorno != null)
                    {
                        mensagem = MensagemDeErro.EmpresaJaCadastrada;
                        return true;
                    }
                    else if (empresaImRetorno != null && empresaIeRetorno != null)
                    {
                        if (empresaImRetorno.InscricaoMunicipal == String.Empty && empresaIeRetorno.InscricaoEstadual == String.Empty)
                        {
                            mensagem = MensagemDeSucesso.AtualizarOK;
                            return false;
                        }
                        else
                        {
                            mensagem = MensagemDeErro.EmpresaJaCadastrada;
                            return true;
                        }
                    }
                    else if (empresaImRetorno == null && empresaIeRetorno == null)
                    {
                        mensagem = MensagemDeSucesso.AtualizarOK;
                        return false;
                    }
                    else if (empresaImRetorno != null)
                    {
                        if (empresaImRetorno.InscricaoMunicipal == String.Empty)
                        {
                            mensagem = MensagemDeSucesso.AtualizarOK;
                            return false;
                        }
                        else
                        {
                            mensagem = MensagemDeErro.EmpresaJaCadastrada;
                            return true;
                        }
                    }
                    else if (empresaIeRetorno != null)
                    {
                        if (empresaIeRetorno.InscricaoEstadual == String.Empty)
                        {
                            mensagem = MensagemDeSucesso.AtualizarOK;
                            return false;
                        }
                        else
                        {
                            mensagem = MensagemDeErro.EmpresaJaCadastrada;
                            return true;
                        }
                    }
                    else
                    {
                        mensagem = MensagemDeErro.EmpresaJaCadastrada;
                        return true;
                    }
                }
            }
        }

        public bool ExisteUsuario(int empresaId, int usuarioId, string email, bool isUpdate, out string mensagem)
        {
            var usuarioCpfUpdateRetorno = _context.Usuario.AsNoTracking().FirstOrDefault(u => u.EmpresaId == empresaId && u.Email == email && u.Id != usuarioId);
            var usuarioCpfAdd = _context.Usuario.AsNoTracking().Where(u => u.EmpresaId == empresaId);
            if (ExisteEmpresaCadastrada(empresaId))
            {
                if (isUpdate)
                {
                    if (usuarioId != null || usuarioId != 0)
                    {
                        if (usuarioCpfUpdateRetorno != null)
                        {
                            mensagem = MensagemDeErro.UsuarioJaCadastrado;
                            return true;
                        }
                        else
                        {
                            mensagem = MensagemDeSucesso.AtualizarOK;
                            return false;
                        }
                    }
                    else
                    {
                        mensagem = MensagemDeErro.UsuarioSemId;
                        return true;
                    }
                }
                else
                {
                    var usuarioCpf = usuarioCpfAdd.FirstOrDefault(u => u.Email == email);
                    if (usuarioCpf != null)
                    {
                        mensagem = MensagemDeErro.UsuarioJaCadastrado;
                        return true;
                    }
                    else
                    {
                        mensagem = MensagemDeSucesso.CadastrarOk;
                        return false;
                    }
                }
            }
            else
            {
                mensagem = MensagemDeErro.EmpresaUsuarioInexistente;
                return true;
            }
        }

        public Produto ExisteProduto(int empresaId, string nomeProduto, decimal preco, double codigo, out string mensagem)
        {
            if (ExisteEmpresaCadastrada(empresaId))
            {
                var produto = _context.Produto.AsNoTracking().Where(p => p.EmpresaId == empresaId && p.Nome == nomeProduto && p.Preco == preco && p.Codigo == codigo).OrderBy(p => p.Id).FirstOrDefault();
                if (produto == null)
                {
                    mensagem = MensagemDeSucesso.CadastrarOk;
                    return null;
                }
                else
                {
                    var nomeProdutoView = nomeProduto.Replace(" ", "");
                    var nomeProdutoRetorno = produto.Nome.Replace(" ", "");
                    if (nomeProdutoRetorno == nomeProdutoView)
                    {
                        mensagem = MensagemDeErro.ExisteProduto;
                        return produto;
                    }
                    else
                    {
                        mensagem = MensagemDeErro.ProdutoErroAoConsultar;
                        return null;
                    }
                }
            }
            else
            {
                mensagem = MensagemDeErro.EmpresaProdutoInexistente;
                return null;
            }
        }

        public bool ExisteProdutoUpdate(Produto produtoBanco, Produto produtoView, out Produto produtoAtualizaQuantidade, out string mensagem)
        {
            if (ExisteEmpresaCadastrada(produtoView.EmpresaId))
            {
                if (produtoView.Id != null && produtoView.Id != 0)
                {
                    var produtoRetornoUpdate = _context.Produto.AsNoTracking().Where(p => p.EmpresaId == produtoView.EmpresaId && p.Nome == produtoView.Nome && p.Preco == produtoView.Preco && p.Codigo == produtoView.Codigo && p.FornecedorId == produtoView.FornecedorId && p.Id != produtoView.Id);
                    if (produtoView.Id == produtoBanco.Id && produtoView.Nome == produtoBanco.Nome && produtoView.Quantidade == produtoBanco.Quantidade && produtoView.Preco == produtoBanco.Preco && produtoView.Codigo == produtoBanco.Codigo && produtoView.EmpresaId == produtoBanco.EmpresaId && produtoView.FornecedorId == produtoBanco.FornecedorId)
                    {
                        mensagem = MensagemDeSucesso.AtualizarOK;
                        produtoAtualizaQuantidade = null;
                        return true;
                    }
                    else
                    {
                        if (produtoRetornoUpdate == null)
                        {
                            mensagem = MensagemDeSucesso.AtualizarOK;
                            produtoAtualizaQuantidade = null;
                            return true;
                        }
                        else
                        {
                            var produtoReturnResposta = produtoRetornoUpdate.FirstOrDefault(p => p.Nome == produtoView.Nome && p.Preco == produtoView.Preco && p.Codigo == produtoView.Codigo && p.EmpresaId == produtoView.EmpresaId && p.FornecedorId == produtoView.FornecedorId);
                            if (produtoReturnResposta != null)
                            {
                                mensagem = MensagemDeSucesso.AtualizarQuantidadeProduto;
                                produtoAtualizaQuantidade = new Produto()
                                {
                                    Id = produtoReturnResposta.Id,
                                    Nome = produtoReturnResposta.Nome,
                                    Quantidade = produtoReturnResposta.Quantidade,
                                    Ativo = produtoReturnResposta.Ativo,
                                    Preco = produtoReturnResposta.Preco,
                                    Codigo = produtoReturnResposta.Codigo,
                                    DataCadastroProduto = produtoReturnResposta.DataCadastroProduto,
                                    EmpresaId = produtoReturnResposta.EmpresaId,
                                    FornecedorId = produtoReturnResposta.FornecedorId
                                };

                                return true;
                            }
                            else
                            {
                                mensagem = MensagemDeSucesso.AtualizarOK;
                                produtoAtualizaQuantidade = null;
                                return true;
                            }
                        }
                    }
                }
                mensagem = MensagemDeErro.ProdutoErroAtualizar;
                produtoAtualizaQuantidade = null;
                return true;
            }
            else
            {
                mensagem = MensagemDeErro.EmpresaProdutoInexistente;
                produtoAtualizaQuantidade = null;
                return true;
            }
        }

        public async Task<bool> ExisteEnderecoProduto(int empresaId, string nomeEndereco, bool isUpdate)
        {
            if (isUpdate)
            {
                var nomeEnderecoProdutoUpdate = _context.EnderecoProduto.AsNoTracking().FirstOrDefault(ep => ep.NomeEndereco == nomeEndereco && ep.EmpresaId != empresaId);

                if (nomeEnderecoProdutoUpdate == null)
                {
                    return false;
                }
                else if (nomeEnderecoProdutoUpdate.NomeEndereco == nomeEndereco)
                {
                    return true;
                }
                return true;
            }
            else
            {
                var nomeEnderecoProduto = _context.EnderecoProduto.AsNoTracking().FirstOrDefault(ep => ep.NomeEndereco == nomeEndereco);
                if (nomeEnderecoProduto == null)
                {
                    return false;
                }
                else if (nomeEnderecoProduto.NomeEndereco == nomeEndereco)
                {
                    return true;
                }
            }
            return false;
        }

        public bool VisualizarEmpresa(int empresaId, out string mensagem)
        {
            if (empresaId.Equals(((int)TipoEmpresa.Administrador)))
            {
                mensagem = MensagemDeSucesso.VisualizarOK;
                return true;
            }
            else
            {
                mensagem = MensagemDeErro.VisualizarEmpresa;
                return false;
            }
        }

        public bool ExisteEmpresaCadastrada(int empresaId)
        {
            var EmpresaExiste = _context.Empresa.AsNoTracking().FirstOrDefault(e => e.Id == empresaId);
            if (EmpresaExiste == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }        

        public string AcertarNome(string nome)
        {
            var nomeSemEspacos = Regex.Replace(nome, " {2,}", " ");
            nomeSemEspacos = nomeSemEspacos.Trim();
            return nomeSemEspacos;
        }       

        public UsuarioLoginViewModel Login(string email, string senha, out string mensagem)
        {
            var usuario = (from users in _context.Usuario
                           join func in _context.Funcionario on users.FuncionarioId equals func.Id
                           join empre in _context.Empresa on users.EmpresaId equals empre.Id
                           select new
                           {                              
                               NomeUsuario = func.Nome,
                               NomeEmpresa = empre.Nome,
                               Email = users.Email,
                               DataCadastroUsuario = users.DataCadastroUsuario,
                               Ativo = users.Ativo,
                               EmpresaId = users.EmpresaId,
                               Senha = users.Senha,
                               FuncionarioId = users.FuncionarioId,
                               UsuarioId = users.Id
                           }).Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            var usuarioRetorno = new UsuarioLoginViewModel()
            {
                NomeEmpresa = usuario.NomeEmpresa,
                NomeUsuario = usuario.NomeUsuario,
                Email = usuario.Email,
                Senha = usuario.Senha,
                DataCadastroUsuario = usuario.DataCadastroUsuario,
                Ativo = usuario.Ativo,
                FuncionarioId = usuario.FuncionarioId,
                EmpresaId = usuario.EmpresaId           
            };

            if (usuarioRetorno != null)
            {
                if (usuarioRetorno.Email == email && usuarioRetorno.Senha == senha)
                {
                    mensagem = MensagemDeSucesso.SucessoSenha;
                    return usuarioRetorno;
                }
                else
                {
                    mensagem = MensagemDeErro.LoginErro;
                    return null;
                }
            }
            else
            {
                mensagem = MensagemDeErro.LoginErro;
                return null;
            }
        }

        public IEnumerable<UsuarioViewModel> RetornarUsuario(int empresaId)
        {
            List<UsuarioViewModel> usuariosRetorno = new List<UsuarioViewModel>();
            var usuarios = (from users in _context.Usuario
                           join func in _context.Funcionario on users.FuncionarioId equals func.Id
                           join empre in _context.Empresa on users.EmpresaId equals empre.Id
                           select new
                           {
                               Id = users.Id,
                               NomeEmpresa = empre.Nome,
                               Nome = func.Nome,
                               Email = users.Email,
                               Senha = users.Senha,
                               DataCadastroUsuario = users.DataCadastroUsuario,
                               Ativo = users.Ativo,
                               EmpresaId = users.EmpresaId,
                               FuncionarioId = users.FuncionarioId
                           }).Where(u => u.EmpresaId == empresaId).ToList();
            
            foreach (var item in usuarios)
            {
                usuariosRetorno.Add(new UsuarioViewModel(item.Id, item.NomeEmpresa, item.Nome, item.Email, item.Senha, item.DataCadastroUsuario, item.Ativo, item.FuncionarioId, item.EmpresaId));
            }            

            return usuariosRetorno;
        }

        public IEnumerable<FuncionariosUsuariosViewModel> RetornarFuncionariosUsuario(int empresaId)
        {
            List<FuncionariosUsuariosViewModel> funcionariosUsuariosRetorno = new List<FuncionariosUsuariosViewModel>();
            var usuarios = _context.Usuario.AsNoTracking().Where(u => u.EmpresaId == empresaId).ToList();
            var funcionarios = _context.Funcionario.AsNoTracking().Where(f => f.EmpresaId == empresaId).ToList();
            var funcionariosUsuarios = from func in funcionarios
                                       from user in usuarios
                                       where func.Id == user.FuncionarioId
                                       select func;
            var listaFinal = funcionarios.Except(funcionariosUsuarios);
            
            foreach (var item in listaFinal)
            {
                funcionariosUsuariosRetorno.Add(new FuncionariosUsuariosViewModel(item.Id, item.Nome, item.Endereco, item.Bairro, item.Numero, item.Municipio, item.UF, item.Pais, item.CEP, item.Complemento, item.Telefone, item.Email, item.CPF, item.DataCadastroFuncionario, item.Ativo, item.EmpresaId));
            }
            return funcionariosUsuariosRetorno;
        }      
    }
}