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
        public ActionResult Extrato(FormCollection form, int tipoCliente, string nome, double cpf)
        {
            if (ModelState.IsValid)
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
            }
            else
            {
                return View("Transacao");
            }
                

            return View();
        }
    }
}