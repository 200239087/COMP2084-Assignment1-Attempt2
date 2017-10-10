using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COMP2084_Assignment1.Models;

namespace COMP2084_Assignment1.Controllers
{
    public class ConsoleManagerController : Controller
    {
        private GameControllerModel db = new GameControllerModel();

        // GET: ConsoleManager
        public ActionResult Index()
        {
            var consoles = db.consoles.Include(c => c.consoles1);
            return View(consoles.ToList());
        }

        // GET: ConsoleManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            console console = db.consoles.Find(id);
            if (console == null)
            {
                return HttpNotFound();
            }
            return View(console);
        }

        // GET: ConsoleManager/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.consoles, "id", "name");
            return View();
        }

        // POST: ConsoleManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,company,bio_link")] console console)
        {
            if (ModelState.IsValid)
            {
                db.consoles.Add(console);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.consoles, "id", "name", console.id);
            return View(console);
        }

        // GET: ConsoleManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            console console = db.consoles.Find(id);
            if (console == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.consoles, "id", "name", console.id);
            return View(console);
        }

        // POST: ConsoleManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,company,bio_link")] console console)
        {
            if (ModelState.IsValid)
            {
                db.Entry(console).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.consoles, "id", "name", console.id);
            return View(console);
        }

        // GET: ConsoleManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            console console = db.consoles.Find(id);
            if (console == null)
            {
                return HttpNotFound();
            }
            return View(console);
        }

        // POST: ConsoleManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            console console = db.consoles.Find(id);
            db.consoles.Remove(console);
            db.SaveChanges();
            return RedirectToAction("Index");
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
