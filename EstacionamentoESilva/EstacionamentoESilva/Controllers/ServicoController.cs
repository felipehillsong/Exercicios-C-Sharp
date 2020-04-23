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

        // GET: ServicosCadastrados
        public ActionResult ServicosCadastrados()
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(db.Servico.ToList());
        }

        // GET: ServicoHorista
        public ActionResult Horista(int? id)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculoes.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }

            ViewBag.DiaEntrada = DateTime.Now.ToString("dd/MM");
            ViewBag.HoraEntrada = DateTime.Now.ToString("HH:mm");

            return View(veiculo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Horista(int? id, Servico servico)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculoes.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }

            servico = new Servico
            {
                NomeCliente = veiculo.Cliente.Nome,
                Marca = veiculo.Marca,
                Placas = veiculo.Placa,
                DiaEntrada = DateTime.Now,                
                HoraEntrada = DateTime.Now,
                HoraSaida = null,
                DiaSaida = null,
                MesEntrada = DateTime.Now,
                MesSaida = null,
                TipoServico = Acesso.ServicoStatus.Horista,
                ServicoStatus = Acesso.ServicoStatus.Aberto


            };

            db.Servico.Add(servico);
            db.SaveChanges();
            return RedirectToAction("ServicosCadastrados");
        }

        // GET: ServicoDiarista
        public ActionResult Diarista(int? id)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculoes.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }

            ViewBag.DiaEntrada = DateTime.Now.ToString("dd/MM");
            ViewBag.HoraEntrada = DateTime.Now.ToString("HH:mm");


            return View(veiculo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Diarista(int? id, Servico servico)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculoes.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }

            servico = new Servico
            {
                NomeCliente = veiculo.Cliente.Nome,
                Marca = veiculo.Marca,
                Placas = veiculo.Placa,
                DiaEntrada = DateTime.Now,
                HoraEntrada = DateTime.Now,
                HoraSaida = null,
                DiaSaida = null,
                MesEntrada = DateTime.Now,
                MesSaida = null,
                TipoServico = Acesso.ServicoStatus.Diarista,
                ServicoStatus = Acesso.ServicoStatus.Aberto
            };

            db.Servico.Add(servico);
            db.SaveChanges();
            return RedirectToAction("ServicosCadastrados");
        }

        // GET: ServicoMensalista
        public ActionResult Mensalista(int? id)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculoes.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }

            ViewBag.DiaEntrada = DateTime.Now.ToString("dd/MM");
            ViewBag.MesEntrada = DateTime.Now.ToString("MM/yyyy");
            ViewBag.HoraEntrada = DateTime.Now.ToString("HH:mm");

            return View(veiculo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mensalista(int? id, Servico servico)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculoes.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }

            servico = new Servico
            {
                NomeCliente = veiculo.Cliente.Nome,
                Marca = veiculo.Marca,
                Placas = veiculo.Placa,
                DiaEntrada = DateTime.Now,
                HoraEntrada = DateTime.Now,
                HoraSaida = null,
                DiaSaida = null,
                MesEntrada = DateTime.Now,
                MesSaida = null,
                TipoServico = Acesso.ServicoStatus.Mensalista,
                ServicoStatus = Acesso.ServicoStatus.Aberto
            };

            db.Servico.Add(servico);
            db.SaveChanges();
            return RedirectToAction("ServicosCadastrados");
        }        

        // GET: Servico/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

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

        // GET: Servico/Edit/5
        public ActionResult FecharServico(int? id)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servico.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }

            Acesso.Valores valores = new Acesso.Valores();

            switch (servico.TipoServico)
            {
                case Acesso.ServicoStatus.Horista:
                    servico.Valor = valores.Horista();
                    var anoHojeH = DateTime.Now;
                    var mesHojeH = DateTime.Now;
                    var diaHojeH = DateTime.Now;
                    var horaHojeH = DateTime.Now;

                    var anoAgoraH = anoHojeH.Year;
                    var diaAgoraH = diaHojeH.Day;                   
                    var mesAgoraH = mesHojeH.Month;
                    var horaAgoraH = horaHojeH.Hour;

                    var anoEntradaH = servico.HoraEntrada.Value.Year;
                    var mesEntradaH = servico.HoraEntrada.Value.Month;
                    var diaEntradaH = servico.HoraEntrada.Value.Day;
                    var horaEntradaH = servico.HoraEntrada.Value.Hour;
                    var horaSaidaH = horaEntradaH + 1;


                    if (anoEntradaH == anoAgoraH && mesEntradaH == mesAgoraH)
                    {
                        if (diaEntradaH == diaAgoraH)
                        {
                            DateTime dataCompletaHoje = DateTime.Now;
                            DateTime dataEntradaCompleta = servico.HoraEntrada.Value;
                            TimeSpan subtracaoDeTempo = dataCompletaHoje - dataEntradaCompleta;
                            var horasQueFicou = subtracaoDeTempo.TotalHours;
                            decimal totalHoras = decimal.Parse(horasQueFicou.ToString());

                            servico.Valor *= totalHoras;
                        }
                        else if (diaAgoraH > diaEntradaH)
                        {
                            DateTime dataCompletaHoje = DateTime.Now;
                            DateTime dataEntradaCompleta = servico.HoraEntrada.Value;
                            TimeSpan subtracaoDeTempo = dataCompletaHoje - dataEntradaCompleta;               
                            var horasQueFicou = subtracaoDeTempo.TotalHours;
                            decimal totalHoras = decimal.Parse(horasQueFicou.ToString());

                            servico.Valor *= totalHoras;
                        }
                        
                    }else if(mesEntradaH != mesAgoraH || anoEntradaH != anoAgoraH)
                    {
                        DateTime dataCompletaHoje = DateTime.Now;
                        DateTime dataEntradaCompleta = servico.HoraEntrada.Value;
                        TimeSpan subtracaoDeTempo = dataCompletaHoje - dataEntradaCompleta;
                        var horasQueFicou = subtracaoDeTempo.TotalHours;
                        decimal totalHoras = decimal.Parse(horasQueFicou.ToString());

                        servico.Valor *= totalHoras;
                    }          
                    break;
                case Acesso.ServicoStatus.Diarista:
                    servico.Valor = valores.Diarista();                  
                    break;
                case Acesso.ServicoStatus.Mensalista:          
                    break;
                default:
                    break;
            }
            return View(servico);
        }

        // POST: ServicoHorista/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FecharServico([Bind(Include = "ServicoId,NomeCliente,Marca,Placas,DiaEntrada,DiaSaida,MesEntrada,MesSaida,HoraEntrada,HoraSaida,Valor")] Servico servico)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (ModelState.IsValid)
            {
                if (servico.ServicoStatus == Acesso.ServicoStatus.Horista)
                {   
                    servico.ServicoStatus = Acesso.ServicoStatus.Fechado;
                    ViewBag.Status = servico.ServicoStatus;
                    db.Entry(servico).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ServicosCadastrados");
                }

                if (servico.ServicoStatus == Acesso.ServicoStatus.Diarista)
                {
                    servico.Valor = 20;
                    db.Entry(servico).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ServicosCadastrados");
                }

                if (servico.ServicoStatus == Acesso.ServicoStatus.Mensalista)
                {
                    servico.Valor = 120;
                    db.Entry(servico).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ServicosCadastrados");
                }

            }
            return View(servico);
        }

        //GET: ServicoDelete/5
        public ActionResult Delete(int? id)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

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

        // POST: Servico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["nomeUsuarioLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

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
