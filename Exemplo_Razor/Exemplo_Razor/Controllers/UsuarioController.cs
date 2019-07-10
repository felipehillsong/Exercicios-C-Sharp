using Exemplo_Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exemplo_Razor.Controllers
{
    public class UsuarioController : Controller
    {
        Usuario usuario = new Usuario();

        // GET: Usuario
        public ActionResult IndexFormulario()
        {
            return View(usuario);
        }

        [HttpPost]
        public ActionResult IndexFormulario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                return View("MostrarFormulario", usuario);
            }
            else
            {
                return View(usuario);
            }
        } 

        public ActionResult MostrarFormulario()
        {
            return View();
        }
    }
}