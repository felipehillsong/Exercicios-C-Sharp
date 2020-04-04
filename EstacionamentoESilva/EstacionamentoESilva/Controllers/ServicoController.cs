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

        // GET: ServicoHorista
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
        public ActionResult Horista(int? id, Servico servicoHorista)
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

            servicoHorista = new Servico
            {
                NomeCliente = veiculo.Cliente.Nome,
                Marca = veiculo.Marca,
                Placas = veiculo.Placa,
                HoraEntrada = DateTime.Now,
                HoraSaida = DateTime.Now.AddHours(1),
                DiaEntrada = DateTime.Now,
                DiaSaida = DateTime.Now,
                MesEntrada = DateTime.Now,
                MesSaida = DateTime.Now
                
            };

            db.Servico.Add(servicoHorista);
            db.SaveChanges();
            return RedirectToAction("ServicosCadastrados");
        }

        // GET: ServicoDiarista
        public ActionResult Diarista(int? id)
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
            ViewBag.HoraSaida = DateTime.Now.ToString("HH:mm");
            ViewBag.DiaEntrada = DateTime.Now.ToString("dd/MM");
            ViewBag.DiaSaida = DateTime.Now.AddDays(1).ToString("dd/MM");


            return View(veiculo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Diarista(int? id, Servico servicoHorista)
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

            servicoHorista = new Servico
            {
                NomeCliente = veiculo.Cliente.Nome,
                Marca = veiculo.Marca,
                Placas = veiculo.Placa,
                HoraEntrada = DateTime.Now,
                HoraSaida = DateTime.Now,
                DiaEntrada = DateTime.Now,
                DiaSaida = DateTime.Now.AddDays(1),
                MesEntrada = DateTime.Now,
                MesSaida = DateTime.Now

            };

            db.Servico.Add(servicoHorista);
            db.SaveChanges();
            return RedirectToAction("ServicosCadastrados");
        }

        // GET: ServicoMensalista
        public ActionResult Mensalista(int? id)
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
            ViewBag.HoraSaida = DateTime.Now.ToString("HH:mm");
            ViewBag.DiaEntrada = DateTime.Now.ToString("dd/MM");
            ViewBag.DiaSaida = DateTime.Now.ToString("dd/MM");
            ViewBag.MesEntrada = DateTime.Now.ToString("MM/yyyy");
            ViewBag.MesSaida = DateTime.Now.AddMonths(1).ToString("MM/yyyy");


            return View(veiculo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mensalista(int? id, Servico servicoHorista)
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

            servicoHorista = new Servico
            {
                NomeCliente = veiculo.Cliente.Nome,
                Marca = veiculo.Marca,
                Placas = veiculo.Placa,
                HoraEntrada = DateTime.Now,
                HoraSaida = DateTime.Now,
                DiaEntrada = DateTime.Now,
                DiaSaida = DateTime.Now,
                MesEntrada = DateTime.Now,
                MesSaida = DateTime.Now.AddMonths(1)

            };

            db.Servico.Add(servicoHorista);
            db.SaveChanges();
            return RedirectToAction("ServicosCadastrados");
        }

        public ActionResult ServicosCadastrados()
        {
            return View(db.Servico.ToList());
        }

        // GET: ServicoHorista/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servico.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        //// GET: ServicoHorista/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Servico servicoHorista = db.ServicoHorista.Find(id);
        //    if (servicoHorista == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(servicoHorista);
        //}

        //// POST: ServicoHorista/Edit/5
        //// Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        //// obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ServicoId,NomeCliente,Marca,Placas,HoraEntrada,HoraSaida")] Servico servicoHorista)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(servicoHorista).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(servicoHorista);
        //}

        // GET: ServicoHorista/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servico.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // POST: ServicoHorista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servico servico = db.Servico.Find(id);
            db.Servico.Remove(servico);
            db.SaveChanges();
            return RedirectToAction("ServicosCadastrados");
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
