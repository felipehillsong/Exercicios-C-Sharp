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
    public class VeiculoController : Controller
    {
        private EstacionamentoESilvaContext db = new EstacionamentoESilvaContext();

        // GET: Veiculo
        public ActionResult Index()
        {
            var acesso = new AcessoAsClasses();
            acesso.Cliente = new Cliente();
            acesso.Veiculo = new Veiculo();

            var list = db.Clientes.ToList();
            list.Add(new Cliente { ClienteId = 0, Nome = "[Selecione um cliente]" });
            list = list.OrderBy(x => x.NomeCompleto).ToList();
            ViewBag.ClienteId = new SelectList(list, "ClienteId", "NomeCompleto");
            var veiculoes = db.Veiculoes.Include(v => v.Cliente);
            return View(veiculoes.ToList());
        }

        // GET: Veiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculoes.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: Veiculo/Create
        public ActionResult Create()
        {
            var list = db.Clientes.ToList();
            list.Add(new Cliente { ClienteId = 0, Nome = "[Selecione um cliente]" });
            list = list.OrderBy(x => x.NomeCompleto).ToList();
            ViewBag.ClienteId = new SelectList(list, "ClienteId", "NomeCompleto");      
            return View();
        }

        // POST: Veiculo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VeiculoId,Marca,Placa,Observacoes,ClienteId")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Veiculoes.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", veiculo.ClienteId);
            return View(veiculo);
        }

        // GET: Veiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculoes.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", veiculo.ClienteId);
            return View(veiculo);
        }

        // POST: Veiculo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VeiculoId,Marca,Placa,Observacoes,ClienteId")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", veiculo.ClienteId);
            return View(veiculo);
        }

        // GET: Veiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculoes.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veiculo veiculo = db.Veiculoes.Find(id);
            db.Veiculoes.Remove(veiculo);
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
