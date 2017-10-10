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
    public class GameManagerController : Controller
    {
        private GameControllerModel db = new GameControllerModel();

        // GET: GameManager
        public ActionResult Index()
        {
            var games = db.games.Include(g => g.console);
            return View(games.ToList());
        }

        // GET: GameManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            game game = db.games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: GameManager/Create
        public ActionResult Create()
        {
            ViewBag.console_id = new SelectList(db.consoles, "id", "name");
            return View();
        }

        // POST: GameManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,company,rating,console_id")] game game)
        {
            if (ModelState.IsValid)
            {
                db.games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.console_id = new SelectList(db.consoles, "id", "name", game.console_id);
            return View(game);
        }

        // GET: GameManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            game game = db.games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.console_id = new SelectList(db.consoles, "id", "name", game.console_id);
            return View(game);
        }

        // POST: GameManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,company,rating,console_id")] game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.console_id = new SelectList(db.consoles, "id", "name", game.console_id);
            return View(game);
        }

        // GET: GameManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            game game = db.games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: GameManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            game game = db.games.Find(id);
            db.games.Remove(game);
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
