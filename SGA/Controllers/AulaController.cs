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
    public class AulaController : Controller
    {

        private readonly Context.AppContext db = new Context.AppContext();

        public ActionResult Index()
        {
            var result = db.Aulas.ToList().Where(a => a.Status != "D");

            foreach(var r in result)
            {
                var professor = db.Professores.Where(t => t.ProfessorId == r.ProfessorId).FirstOrDefault();

                if(professor != null)
                {
                    r.Professor = professor;
                }
            }
            return View(result);
        }

        public ActionResult Horario()
        {
            var result = new List<HorarioViewModel>();

            var culture =  new System.Globalization.CultureInfo("pt-BR") ;
            var model = db.Aulas.ToList().Where(a => a.Status != "D").OrderBy(t => t.Horario).ToList();
            //

            foreach (var r in model)
            {
                var professor = db.Professores.Where(t => t.ProfessorId == r.ProfessorId).FirstOrDefault();
                var ementa = db.Ementas.Where(t => t.AulaId == r.AulaId).ToList();
                var temp = new HorarioViewModel
                {
                    Data = string.Format("{0:dd/MM/yyyy}", r.Horario.Date),
                    DiaDaSemana = culture.DateTimeFormat.GetDayName(r.Horario.DayOfWeek),
                    Horario = string.Concat(r.Horario.Hour.ToString(), ":", r.Horario.Minute.ToString()),
                    Materia = r.Titulo,
                    Professor = (professor != null) ? professor.Nome : "",
                    EmentaId = ementa.FirstOrDefault()?.EmentaId
                };

                result.Add(temp);
            }

            return View(result);
        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Professores = new List<Professor> { new Professor() };
            ViewBag.Professores.AddRange(db.Professores.ToList().Where(a => a.Status != "D"));
            return View();
        }


        [HttpPost]
        public ActionResult Create(Aula aula)
        {

            aula.DtCadastro = DateTime.Now;
            aula.Status = "A";

            if (ModelState.IsValid)
            {
                db.Aulas.Add(aula);
                db.SaveChanges();
            }
            return View("Index", db.Aulas.ToList());
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Professores = new List<Professor> { new Professor() };
            ViewBag.Professores.AddRange(db.Professores.ToList().Where(a => a.Status != "D"));

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var registro = db.Aulas.Find(id);

            registro.Professor = db.Professores.Where(t => t.ProfessorId == registro.ProfessorId).FirstOrDefault();

            return View(registro);
        }

        [HttpPost]
        public ActionResult Edit(Aula model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Aula");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var registro = db.Aulas.Find(id);

            return View(registro);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var registro = db.Aulas.Find(id);
            registro.Status = "D";
            db.Entry(registro).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Aula");
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