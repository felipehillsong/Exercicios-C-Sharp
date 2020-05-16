using EstacionamentoESilva.Data;
using EstacionamentoESilva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstacionamentoESilva.Controllers
{
    public class LoginController : Controller
    {
        private EstacionamentoESilvaContext db = new EstacionamentoESilvaContext();

        //GET: Login
         public ActionResult Login()
         {
            return View();
         }

        //POST: Funcionario/Login
       [HttpPost]
       [ValidateAntiForgeryToken]
         public ActionResult Login(Funcionario funcionario)
         {
            using (EstacionamentoESilvaContext banco = new EstacionamentoESilvaContext())
            {
                string email = "admin@estacionamento.com";
                string senha = "2251";

                if (funcionario.Email == email && funcionario.Senha == senha)
                {
                    Session["nomeUsuarioLogado"] = "Administrador";
                    return RedirectToAction("ServicosCadastrados", "Servico");

                }
                else if (funcionario.Email == "" && funcionario.Senha == "")
                {
                    return RedirectToAction("Login");
                }              

                string senhaCriptografada = CriptograrSenha.CalculaHash(funcionario.Senha);
                funcionario.Senha = senhaCriptografada;
                var usuario = banco.Funcionarios.Where(x => x.Email.Equals(funcionario.Email) && x.Senha.Equals(funcionario.Senha)).FirstOrDefault();
                if (usuario != null)
                {
                    Session["nomeUsuarioLogado"] = usuario.Nome.ToString();
                    return RedirectToAction("ServicosCadastrados", "Servico");
                }

            }
            return View(funcionario);
         }

        //GET: Login
        public ActionResult Logout()
        {
            Session["nomeUsuarioLogado"] = null;
            return RedirectToAction("Login");
        }
    }
}