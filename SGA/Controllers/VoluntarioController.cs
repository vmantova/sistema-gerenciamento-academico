using SGA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGA.Context;
using System.Net;
using System.Data.Entity;

namespace SGA.Controllers
{
    public class VoluntarioController : Controller
    {
        private Context.AppContext db = new Context.AppContext();
             
                
        public ActionResult Index()
        {
            return View("Index",db.Voluntarios.ToList().Where(v => v.Status != "D"));
        }

  
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Voluntario aula)
        {

            aula.DtCadastro = DateTime.Now;
            aula.Status = "A";

            if(ModelState.IsValid)
            {
                db.Voluntarios.Add(aula);
                db.SaveChanges();
            }
            return View("Index",db.Voluntarios.ToList());
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var registro = db.Voluntarios.Find(id);

            return View(registro);
        }

        [HttpPost]
        public ActionResult Edit(Voluntario model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Voluntario");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var registro = db.Voluntarios.Find(id);

            return View(registro);
        }


        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var registro = db.Voluntarios.Find(id);

            if(registro != null)
            {
                registro.Status = "D";
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();

            }
           
            return RedirectToAction("Index", "Voluntario");
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