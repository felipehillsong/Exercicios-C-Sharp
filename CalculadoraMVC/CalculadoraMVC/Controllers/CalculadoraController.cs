using CalculadoraMVC.Models;
using CalculadoraMVC.Processamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculadoraMVC.Controllers
{
    public class CalculadoraController : Controller
    {
        // GET: Calculadora
        public ActionResult Index()
        {
            CalculadoraModel calculadora = new CalculadoraModel();
            return View(calculadora);
        }
        [HttpPost]
        public ActionResult Resultado(FormCollection form, double numero1, string operador, double numero2)
        {            
            numero1 = Convert.ToDouble(form["Numero1"]);
            operador = form["Operador"];
            numero2 = Convert.ToDouble(form["Numero2"]);

            Processar processar = new Processar();
            ViewBag.Resultado = processar.EscolherOperacao(numero1, operador, numero2);
            
            return View();
        }
    }
}