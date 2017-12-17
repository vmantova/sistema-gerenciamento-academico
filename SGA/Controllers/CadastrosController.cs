using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGA.Controllers
{
    public class CadastrosController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}