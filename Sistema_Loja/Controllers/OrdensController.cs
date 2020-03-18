using Sistema_Loja.Models;
using Sistema_Loja.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Loja.Controllers
{
    public class OrdensController : Controller
    {
        private Sistema_LojaContext db = new Sistema_LojaContext();

        // GET: Ordens
        public ActionResult NovaOrdem()
        {
            var ordemView = new OrdemView();
            ordemView.Customizar = new Customizar();
            ordemView.Produtos = new List<ProdutoOrdem>();
            Session["ordemView"] = ordemView;

            var list = db.Customizars.ToList();
            list.Add(new Customizar { CustomizarId = 0, Nome = "[Selecione um cliente]" });
            list = list.OrderBy(x => x.NomeCompleto).ToList();
            ViewBag.CustomizarId = new SelectList(list, "CustomizarId", "NomeCompleto");
            return View(ordemView);
        }
        [HttpPost]
        public ActionResult NovaOrdem(OrdemView ordemView)
        {
            var list = db.Customizars.ToList();
            list.Add(new Customizar { CustomizarId = 0, Nome = "[Selecione um cliente]" });
            list = list.OrderBy(x => x.NomeCompleto).ToList();
            ViewBag.CustomizarId = new SelectList(list, "CustomizarId", "NomeCompleto");
            return View(ordemView);
        }

        public ActionResult AddProduto()
        {           
            var list = db.Produtoes.ToList();
            list.Add(new ProdutoOrdem { ProdutoId = 0, Descricao = "[Selecione um produto]" });
            list = list.OrderBy(x => x.Descricao).ToList();
            ViewBag.ProdutoId = new SelectList(list, "ProdutoId", "Descricao");
            return View();
        }
        [HttpPost]
        public ActionResult AddProduto(ProdutoOrdem produtoOrdem)
        {
            var ordemView = Session["ordemView"] as OrdemView;
            var list = db.Produtoes.ToList();
            var produtoId = int.Parse(Request["ProdutoId"]);
            if(produtoId == 0)
            {
                list.Add(new ProdutoOrdem { ProdutoId = 0, Descricao = "[Selecione um produto]" });
                list = list.OrderBy(x => x.Descricao).ToList();
                ViewBag.ProdutoId = new SelectList(list, "ProdutoId", "Descricao");
                ViewBag.Error = "Selecione um produto";
                return View(produtoOrdem);
            }

            var produto = db.Produtoes.Find(produtoId);
            if (produto == null)
            {
                list.Add(new ProdutoOrdem { ProdutoId = 0, Descricao = "[Selecione um produto]" });
                list = list.OrderBy(x => x.Descricao).ToList();
                ViewBag.ProdutoId = new SelectList(list, "ProdutoId", "Descricao");
                ViewBag.Error = "Não existe o produto selecionado";
                return View(produtoOrdem);
            }

            produtoOrdem = ordemView.Produtos.Find(p => p.ProdutoId == produtoId);


            produtoOrdem = new ProdutoOrdem
            {
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                ProdutoId = produto.ProdutoId,
                Quantidade = float.Parse(Request["Quantidade"])                
            };
            ordemView.Produtos.Add(produtoOrdem);

            var listCliente = db.Customizars.ToList();
            listCliente.Add(new Customizar { CustomizarId = 0, Nome = "[Selecione um cliente]" });
            listCliente = listCliente.OrderBy(x => x.NomeCompleto).ToList();
            ViewBag.CustomizarId = new SelectList(listCliente, "CustomizarId", "NomeCompleto");

            return View("NovaOrdem", ordemView);
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