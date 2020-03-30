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
    public class ServicoController : Controller
    {
        private EstacionamentoESilvaContext db = new EstacionamentoESilvaContext();

        public ActionResult TipoServico(int? id)
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

        // GET: Servico/Horista
        public ActionResult Horista(int? id)
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

            ViewBag.HoraEntrada = DateTime.Now.ToString("HH:mm");
            ViewBag.HoraSaida = DateTime.Now.AddMinutes(60).ToString("HH:mm");


            return View(veiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Horista(int? id, Servico servico)
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
            using (var transaction = db.Database.BeginTransaction())
            {
                servico = new Servico
                {
                    NomeCliente = veiculo.Cliente.Nome,
                    Marca = veiculo.Marca,
                    Placas = veiculo.Placa,
                    HoraEntrada = veiculo.Servicos.HoraEntrada,
                    HoraSaida = veiculo.Servicos.HoraSaida,                    
                };

                db.Servicoes.Add(servico);
                db.SaveChanges();

                transaction.Commit();

                return RedirectToAction("TodosServicos", servico);
            }
        }

        public ActionResult TodosServicos(Servico servico)
        {
            var servicoes = db.Servicoes.Include(s => s.Cliente);
            return View(servicoes.ToList());
        }


        // GET: Servico
        public ActionResult Index()
        {
            var servicoes = db.Servicoes.Include(s => s.Cliente);
            return View(servicoes.ToList());
        }

        // GET: Servico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicoes.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // GET: Servico/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome");
            return View();
        }

        // POST: Servico/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServicoId,MinutoEntrada,MinutoSaida,HoraEntrada,HoraSaída,MesEntrada,MesSaida,ClienteId,VeiculoId")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                db.Servicoes.Add(servico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", servico.ClienteId);
            return View(servico);
        }

        // GET: Servico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicoes.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", servico.ClienteId);
            return View(servico);
        }

        // POST: Servico/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicoId,MinutoEntrada,MinutoSaida,HoraEntrada,HoraSaída,MesEntrada,MesSaida,ClienteId,VeiculoId")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", servico.ClienteId);
            return View(servico);
        }

        // GET: Servico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicoes.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // POST: Servico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servico servico = db.Servicoes.Find(id);
            db.Servicoes.Remove(servico);
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
