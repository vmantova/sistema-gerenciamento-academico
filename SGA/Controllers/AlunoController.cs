using SGA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace SGA.Controllers
{
    public class AlunoController : Controller
    {
        private readonly Context.AppContext db = new Context.AppContext();

        #region CRUD Methods

        public ActionResult Index()
        {
            return View(db.Alunos.ToList().Where(a => a.Status != "D"));
        }

        public ActionResult Horario()
        {
            return View();
        }

        [WebMethod]
        public JsonResult CalculateAge(string nascimento)
        {
            var date = DateTime.Parse(nascimento);

            var result = DateTime.Now.Year - date.Year;

            return Json(result);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {

            aluno.DtCadastro = DateTime.Now;
            aluno.Status = "A";

            if (ModelState.IsValid)
            {
                db.Alunos.Add(aluno);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(int? id)
        {
            var registro = db.Alunos.Find(id);
            return View(registro);
        }

        [HttpPost]
        public ActionResult Edit(Aluno model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Aluno");
        }

        [HttpGet]
        public ViewResult Delete(int? id)
        {
            var registro = db.Alunos.Find(id);
            return View(registro);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var registro = db.Alunos.Find(id);
            registro.Status = "D";
            db.Entry(registro).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
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
