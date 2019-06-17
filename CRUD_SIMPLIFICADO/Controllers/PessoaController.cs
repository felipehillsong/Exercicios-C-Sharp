using CRUD_SIMPLIFICADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_SIMPLIFICADO.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaRepositorio _pessoaRepositorio;

        public PessoaController()
        {
            _pessoaRepositorio = new PessoaRepositorio();
        }

        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _pessoaRepositorio.Incluir(pessoa);
                return RedirectToAction("ListarClientes");
            }
            return View(pessoa);
        }

        public ActionResult ListarClientes()
        {
            return View(_pessoaRepositorio.ListarTodasPessoas());
        }

        public ActionResult Delete(int id)
        {
            _pessoaRepositorio.Excluir(id);

            return RedirectToAction("ListarClientes");
        }

        public ActionResult Edit(int id)
        {
            return View(_pessoaRepositorio.BuscaPorId(id));
        }

        [HttpPost]
        public ActionResult Edit(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _pessoaRepositorio.Alterar(pessoa);
                return RedirectToAction("ListarClientes");
            }
            return View(pessoa);
        }



    }
}