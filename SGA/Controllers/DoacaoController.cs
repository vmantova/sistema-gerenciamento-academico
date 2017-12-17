using SGA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SGA.Controllers
{
    public class DoacaoController : Controller
    {
        private Context.AppContext db = new Context.AppContext();


        public ActionResult Index()
        {
            return View("Index", db.Doacoes.ToList());
        }

        public ViewResult Inventario()
        {

            var result = db.Doacoes.ToList();
            ViewBag.Total = 0;


            foreach (var r in result)
            {
                var temp = r.Preco * r.Quantidade;
                ViewBag.Total += temp;
            }

            return View(result);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Doacao doacao)
        {

            doacao.DtCadastro = DateTime.Now;
            doacao.Status = "A";

            //var preco = float.Parse(doa)

            if (ModelState.IsValid)
            {
                db.Doacoes.Add(doacao);
                db.SaveChanges();
            }
            return RedirectToAction("Inventario");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var registro = db.Doacoes.Find(id);

            return View(registro);
        }

        [HttpPost]
        public ActionResult Edit(Doacao model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Inventario");
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