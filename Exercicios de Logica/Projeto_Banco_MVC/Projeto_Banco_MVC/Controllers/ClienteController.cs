using Projeto_Banco_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Banco_MVC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Transacao()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Extrato(FormCollection form, int tipoConta, double deposito, double saque, int tipoCliente, string nome, double cpf)
        {
            tipoCliente = Convert.ToInt32(form["tipoCliente"]);

            if (tipoCliente == 1)
            {
                ClienteFisico clienteFisico = new ClienteFisico();

                nome = form["nome"];
                cpf = Convert.ToDouble(form["cpf"]);
                ViewBag.Mensagem = "Cliente Fisico";
                ViewBag.Nome = clienteFisico.PegarNome(nome);
                ViewBag.CPF = clienteFisico.PegarCPF(cpf);
            }

            if (tipoCliente == 2)
            {
                ClienteJuridico clienteJuridico = new ClienteJuridico();

                nome = form["nome"];
                cpf = Convert.ToDouble(form["cpf"]);
                ViewBag.Mensagem = "Cliente Juridico";
                ViewBag.Nome = clienteJuridico.PegarNome(nome);
                ViewBag.CPF = clienteJuridico.PegarCPF(cpf);
            }

            if (tipoConta == 3)
            {
                ContaCorrente contaCorrente = new ContaCorrente();

                deposito = Convert.ToDouble(form["deposito"]);
                saque = Convert.ToDouble(form["saque"]);
                ViewBag.MensagemConta = "Conta Conrrente";
                ViewBag.FoiDepositado = Convert.ToDouble(form["deposito"]);
                ViewBag.FoiSacado = Convert.ToDouble(form["saque"]);
                ViewBag.SaldoInicial = contaCorrente.SaldoComeco();
                ViewBag.Deposito = contaCorrente.Deposito(ViewBag.FoiDepositado);
                ViewBag.Saque = contaCorrente.Saque(ViewBag.FoiSacado);
                ViewBag.SaldoFinal = contaCorrente.MostrarSaldoFinal();
            }

            if(tipoConta == 4)
            {
                ContaPoupanca contaPoupanca = new ContaPoupanca();

                deposito = Convert.ToDouble(form["deposito"]);
                saque = Convert.ToDouble(form["saque"]);
                ViewBag.MensagemConta = "Conta Poupança";
                ViewBag.FoiDepositado = Convert.ToDouble(form["deposito"]);
                ViewBag.FoiSacado = Convert.ToDouble(form["saque"]);
                ViewBag.SaldoInicial = contaPoupanca.SaldoComeco();
                ViewBag.Deposito = contaPoupanca.Deposito(ViewBag.FoiDepositado);
                ViewBag.Saque = contaPoupanca.Saque(ViewBag.FoiSacado);
                ViewBag.MensagemDesconto = "Existe um desconto de 0,10 em cada saque!";
                ViewBag.SaldoFinal = contaPoupanca.MostrarSaldoFinal();
            }

            return View();
        }
        
    }
}