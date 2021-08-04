using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC.Models;

namespace ASP.NET_MVC.Controllers
{
    public class GenreController : Controller
    {
        private BD_GESTION_BIBLIOEntities1 db = new BD_GESTION_BIBLIOEntities1();

        // GET: Genre
        public ActionResult Index()
        {
            return View(db.GENRE.ToList());
        }

        // GET: Genre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENRE gENRE = db.GENRE.Find(id);
            if (gENRE == null)
            {
                return HttpNotFound();
            }
            return View(gENRE);
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "genre_id,libelle")] GENRE gENRE)
        {
            if (ModelState.IsValid)
            {
                db.GENRE.Add(gENRE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gENRE);
        }

        // GET: Genre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENRE gENRE = db.GENRE.Find(id);
            if (gENRE == null)
            {
                return HttpNotFound();
            }
            return View(gENRE);
        }

        // POST: Genre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "genre_id,libelle")] GENRE gENRE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gENRE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gENRE);
        }

        // GET: Genre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENRE gENRE = db.GENRE.Find(id);
            if (gENRE == null)
            {
                return HttpNotFound();
            }
            return View(gENRE);
        }

        // POST: Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GENRE gENRE = db.GENRE.Find(id);
            db.GENRE.Remove(gENRE);
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
