using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_Mapa.Data;
using CRUD_Mapa.Models;

namespace CRUD_Mapa.Controllers
{
    public class MapaController : Controller
    {
        private CRUD_MapaContext db = new CRUD_MapaContext();

        // GET: Mapa
        public ActionResult Index()
        {
            return View(db.Mapas.ToList());
        }


        public ActionResult Lista()
        {
            return View(db.Mapas.ToList());
        }

        // GET: Mapa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mapa mapa = db.Mapas.Find(id);
            if (mapa == null)
            {
                return HttpNotFound();
            }
            return View(mapa);
        }

        // GET: Mapa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mapa/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Latitude,Longitude,Descricao,Localizacao")] Mapa mapa)
        {
            if (ModelState.IsValid)
            {
                db.Mapas.Add(mapa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mapa);
        }

        // GET: Mapa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mapa mapa = db.Mapas.Find(id);
            if (mapa == null)
            {
                return HttpNotFound();
            }
            return View(mapa);
        }

        // POST: Mapa/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Latitude,Longitude,Descricao,Localizacao")] Mapa mapa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mapa);
        }

        // GET: Mapa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mapa mapa = db.Mapas.Find(id);
            if (mapa == null)
            {
                return HttpNotFound();
            }
            return View(mapa);
        }

        // POST: Mapa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mapa mapa = db.Mapas.Find(id);
            db.Mapas.Remove(mapa);
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