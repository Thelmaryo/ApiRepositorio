using PadraoRepositorio.WebMVC.Models;
using PadraoRepositorio.WebMVC.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PadraoRepositorio.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private PessoaAPIServico api = new PessoaAPIServico();

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
            api.Salvar(pessoa);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(api.BuscarPorId(id));
        }

        [HttpPost]
        public ActionResult Edit(Pessoa pessoa)
        {
            api.Atualizar(pessoa);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            api.Excluir(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult Filtro(DataTable dataTable)
        {
            var lista = api.Filtrar(dataTable);
            var result = new DataTableResult {
                data = lista.ToArray(),
                draw = dataTable.draw,
                recordsFiltered = lista.Count()
            };
            return Json(result);
        }
    }
}