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

        //GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Funcionario/Login        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Funcionario funcionario)
        {
            using (EstacionamentoESilvaContext banco = new EstacionamentoESilvaContext())
            {
                var usuario = banco.Funcionarios.Where(x => x.Email.Equals(funcionario.Email) && x.Senha.Equals(funcionario.Senha)).FirstOrDefault();
                if (usuario != null)
                {
                    Session["usuarioLogadoID"] = usuario.FuncionarioId.ToString();
                    Session["nomeUsuarioLogado"] = usuario.Nome.ToString();
                    return RedirectToAction("ServicosCadastrados", "Servico");
                }
            }
            return View(funcionario);
        }

        // GET: Funcionario
        public ActionResult Index()
        {
            return View(db.Funcionarios.ToList());
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int? id)
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

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionario/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FuncionarioId,Nome,Sobrenome,CPF,Endereco,Telefone,Email,Senha")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                string senhaCriptografada = CriptograrSenha.CalculaHash(funcionario.Senha);
                funcionario.Senha = senhaCriptografada;
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funcionario);
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Funcionario/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FuncionarioId,Nome,Sobrenome,CPF,Endereco,Telefone,Email,Senha")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                string senhaCriptografada = CriptograrSenha.CalculaHash(funcionario.Senha);
                funcionario.Senha = senhaCriptografada;
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionario);
            db.SaveChanges();
            return RedirectToAction("Index");
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
