using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Conexao;
using WEB.Models;

namespace WEB.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                var usuarioAplicacao = new UsuarioAplicacao();
                usuarioAplicacao.Salvar(usuarios);
                return RedirectToAction("Usuarios", "Usuarios");
            }
            return View();
        }

    }
}