using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_Loja.Models;

namespace Sistema_Loja.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private Sistema_LojaContext db = new Sistema_LojaContext();

        // GET: TipoDocumento
        public ActionResult Index()
        {
            return View(db.TipoDocumentoes.ToList());
        }

        // GET: TipoDocumento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumento tipoDocumento = db.TipoDocumentoes.Find(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoDocumentoId,Descricao")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                db.TipoDocumentoes.Add(tipoDocumento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumento tipoDocumento = db.TipoDocumentoes.Find(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumento);
        }

        // POST: TipoDocumento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoDocumentoId,Descricao")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDocumento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumento tipoDocumento = db.TipoDocumentoes.Find(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumento);
        }

        // POST: TipoDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDocumento tipoDocumento = db.TipoDocumentoes.Find(id);
            db.TipoDocumentoes.Remove(tipoDocumento);
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
