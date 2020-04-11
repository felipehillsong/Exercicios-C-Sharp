using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EstacionamentoESilva.Data;
using EstacionamentoESilva.Models;

namespace EstacionamentoESilva.Controllers
{
    public class FuncionarioController : Controller
    {
        private EstacionamentoESilvaContext db = new EstacionamentoESilvaContext();

        // GET: Funcionario
        public ActionResult Index()
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (Session["nomeUsuarioLogado"].Equals("Administrador"))
            {
                return View(db.Funcionarios.ToList());
            }
            else{
                return RedirectToAction("Login", "Login");
            }
           
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (Session["nomeUsuarioLogado"].Equals("Administrador"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Funcionario funcionario = db.Funcionarios.Find(id);
                if (funcionario == null)
                {
                    return HttpNotFound();
                }
                return View(funcionario);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }            
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (Session["nomeUsuarioLogado"].Equals("Administrador"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }            
        }

        // POST: Funcionario/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FuncionarioId,Nome,Sobrenome,CPF,Endereco,Telefone,Email,Senha,ConfirmarSenha")] Funcionario funcionario)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (Session["nomeUsuarioLogado"].Equals("Administrador"))
            {
                if (ModelState.IsValid)
                {
                    string senhaCriptografada = CriptograrSenha.CalculaHash(funcionario.Senha);
                    funcionario.Senha = senhaCriptografada;

                    string confirmarSenhaCriptografada = CriptograrSenha.CalculaHash(funcionario.ConfirmarSenha);
                    funcionario.ConfirmarSenha = confirmarSenhaCriptografada;

                    if (senhaCriptografada == confirmarSenhaCriptografada)
                    {
                        db.Funcionarios.Add(funcionario);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Error = "Senhas não conferem!";
                    }
                    
                }

                return View(funcionario);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (Session["nomeUsuarioLogado"].Equals("Administrador"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Funcionario funcionario = db.Funcionarios.Find(id);
                if (funcionario == null)
                {
                    return HttpNotFound();
                }
                return View(funcionario);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }

        // POST: Funcionario/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FuncionarioId,Nome,Sobrenome,CPF,Endereco,Telefone,Email,Senha,ConfirmarSenha")] Funcionario funcionario)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (Session["nomeUsuarioLogado"].Equals("Administrador"))
            {
                if (Session["nomeUsuarioLogado"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }

                string senhaCriptografada = CriptograrSenha.CalculaHash(funcionario.Senha);
                funcionario.Senha = senhaCriptografada;

                string confirmarSenhaCriptografada = CriptograrSenha.CalculaHash(funcionario.ConfirmarSenha);
                funcionario.ConfirmarSenha = confirmarSenhaCriptografada;

                if(senhaCriptografada == confirmarSenhaCriptografada)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(funcionario).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.Error = "Senhas não conferem!";
                }
                return View(funcionario);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (Session["nomeUsuarioLogado"].Equals("Administrador"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Funcionario funcionario = db.Funcionarios.Find(id);
                if (funcionario == null)
                {
                    return HttpNotFound();
                }
                return View(funcionario);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }            
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (Session["nomeUsuarioLogado"].Equals("Administrador"))
            {
                Funcionario funcionario = db.Funcionarios.Find(id);
                db.Funcionarios.Remove(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
