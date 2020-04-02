using EstacionamentoESilva.Data;
using EstacionamentoESilva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EstacionamentoESilva.Controllers
{
    public class TipoServicoController : Controller
    {
        private EstacionamentoESilvaContext db = new EstacionamentoESilvaContext();

        // GET: TipoServico
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
    }
}