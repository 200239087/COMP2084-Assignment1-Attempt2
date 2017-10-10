using COMP2084_Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COMP2084_Assignment1.Controllers
{
    public class HomeController : Controller
    {
        GameControllerModel db = new GameControllerModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consoles()
        {
            var consoles = db.consoles.ToList();

            ViewBag.Message = "Your application description page.";

            return View(consoles);
        }

        public ActionResult Games(string console)
        {
            var c = db.consoles.Include("games").SingleOrDefault(con => con.name == console);

            return View(c);
        }
    }
}