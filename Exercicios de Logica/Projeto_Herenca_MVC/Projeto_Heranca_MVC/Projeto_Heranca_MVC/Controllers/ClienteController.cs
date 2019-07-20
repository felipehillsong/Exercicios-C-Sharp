using Projeto_Heranca_MVC.Cliente;
using Projeto_Heranca_MVC.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Heranca_MVC.Controllers
{
    public class ClienteController : Controller
    {
       

        // GET: Cliente
        public ActionResult Transacao()
        {
            ClienteTransacaoModel model = new ClienteTransacaoModel();
            
            return View(model);
        }        

    }
}