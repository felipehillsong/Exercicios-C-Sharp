using CRUD_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_ADO.Controllers {
    public class PessoaController : Controller {
        private PessoaRepositorio repositorio = new PessoaRepositorio();
        /// <summary>
        /// Vai mandar para View Index uma lista com todos as pessoas cadastradas
        /// </summary>
        /// <returns></returns>
        // GET: Pessoa
        public ActionResult Index() {
            return View(repositorio.GetAll());
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id) {
            return View();
        }
        /// <summary>
        /// vai criar na View uma tela de cadastro de pssoaas
        /// </summary>
        /// <returns></returns>
        // GET: Pessoa/Create
        public ActionResult Create() {
            return View();
        }

        /// <summary>
        /// quando foi clicado no botão salvar na tela cadastro, sera salvo no banco e vai retornar para a tela Index
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        // POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(Pessoa pessoa) {
            // TODO: Add insert logic here
            if (ModelState.IsValid) {
                repositorio.Save(pessoa);
                return RedirectToAction("Index");
            } else {
                return View(pessoa);
            }

        }

       /// <summary>
       /// vai criar uma View para editar e tras os dados da pessoa para ser editado, a pessoa sera pega pelo id
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        // GET: Pessoa/Edit/5
        public ActionResult Edit(int Id) {
            var pessoa = repositorio.GetById(Id);
            if (pessoa == null) {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        /// <summary>
        /// quando clicar no botão salvar na tela de editar, sera salvo no banco e vai retornar para a tela Index
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(Pessoa pessoa) {
            if (ModelState.IsValid) {
                repositorio.Update(pessoa);
                return RedirectToAction("Index");
            } else {
                return View(pessoa);
            }
        }

        /// <summary>
        /// vai criar uma View para deletar a pessoa, a pessoa sera pega pelo id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        // GET: Pessoa/Delete/5
        public ActionResult Delete(int Id) {
            var pessoa = repositorio.GetById(Id);
            if (pessoa == null) {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        /// <summary>
        /// quando clicar em excluir, os dados da pessoa serão excluidos e vai retornar para a tela Index
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        // POST: Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(Pessoa pessoa) {            
            repositorio.Delete(pessoa);
            return RedirectToAction("Index");
        }
    }
}
