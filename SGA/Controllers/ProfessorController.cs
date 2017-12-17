using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGA.Context;
using SGA.Models;

namespace SGA.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly Context.AppContext db = new Context.AppContext();

        #region CRUD Methods

        public ActionResult Index()
        {
            return View(db.Professores.ToList().Where(a => a.Status != "D"));
        }

        public ActionResult Horario()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Professor professor)
        {
            professor.DtCadastro = DateTime.Now;
            professor.Status = "A";

            if (ModelState.IsValid)
            {
                db.Professores.Add(professor);
                db.SaveChanges();
            }
          
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var registro = db.Professores.Find(id);

            return View(registro);
        }

        [HttpPost]
        public ActionResult Edit(Professor model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Professor");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var registro = db.Professores.Find(id);

            return View(registro);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var registro = db.Professores.Find(id);

            if(registro != null)
            {
                registro.Status = "D";
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
            }
            
            return RedirectToAction("Index", "Professor");
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
