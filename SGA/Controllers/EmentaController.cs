using SGA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace SGA.Controllers
{
    public class EmentaController : Controller
    {
        private readonly Context.AppContext db = new Context.AppContext();

        #region CRUD Methods

        public ActionResult Index()
        {
            var result = db.Ementas.ToList().Where(a => a.Status != "D");

            foreach (var item in result)
            {
                var aula = db.Aulas.FirstOrDefault(a => a.AulaId == item.AulaId);

                if (aula != null)
                    item.Aula = aula;
            }

            return View(result);
        }

        public ActionResult Horario()
        {
            return View();
        }

        public ViewResult Detail(int id)
        {
            var result = db.Ementas.Find(id);

            var temp = result.Bibliografia.Split('|');

            ViewBag.Livros = temp;

            var aula = db.Aulas.Find(result.AulaId);

            if (aula != null)
                result.Aula = aula;

            return View(result);
        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Aulas = new List<Aula> { new Aula() };
            ViewBag.Aulas.AddRange(db.Aulas.ToList().Where(a => a.Status != "D"));
            return View();
        }

        [HttpPost]
        public ActionResult Create(Ementa ementa)
        {
            ementa.DtCadastro = DateTime.Now;
            ementa.Status = "A";

            if (ModelState.IsValid)
            {
                db.Ementas.Add(ementa);
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(int? id)
        {
            ViewBag.Aulas = new List<Aula> { new Aula() };
            ViewBag.Aulas.AddRange(db.Aulas.ToList().Where(a => a.Status != "D"));

            var registro = db.Ementas.Find(id);

            registro.Aula = db.Aulas.FirstOrDefault(t => t.AulaId == registro.AulaId);

            return View(registro);
        }

        [HttpPost]
        public ActionResult Edit(Ementa model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Ementa");
        }

        [HttpGet]
        public ViewResult Delete(int? id)
        {
            var registro = db.Ementas.Find(id);
            return View(registro);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var registro = db.Ementas.Find(id);

            if (registro != null)
            {
                registro.Status = "D";
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Ementa");
        }
        #endregion


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