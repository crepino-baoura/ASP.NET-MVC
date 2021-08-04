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
    public class CourantlitteraireController : Controller
    {
        private BD_GESTION_BIBLIOEntities1 db = new BD_GESTION_BIBLIOEntities1();

        // GET: Courantlitteraire
        public ActionResult Index()
        {
            var cOURANTLITTERAIRE = db.COURANTLITTERAIRE.Include(c => c.GENRE);
            return View(cOURANTLITTERAIRE.ToList());
        }

        // GET: Courantlitteraire/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURANTLITTERAIRE cOURANTLITTERAIRE = db.COURANTLITTERAIRE.Find(id);
            if (cOURANTLITTERAIRE == null)
            {
                return HttpNotFound();
            }
            return View(cOURANTLITTERAIRE);
        }

        // GET: Courantlitteraire/Create
        public ActionResult Create()
        {
            ViewBag.genre_id = new SelectList(db.GENRE, "genre_id", "libelle");
            return View();
        }

        // POST: Courantlitteraire/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "commentlitteraire_id,libelle,genre_id")] COURANTLITTERAIRE cOURANTLITTERAIRE)
        {
            if (ModelState.IsValid)
            {
                db.COURANTLITTERAIRE.Add(cOURANTLITTERAIRE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.genre_id = new SelectList(db.GENRE, "genre_id", "libelle", cOURANTLITTERAIRE.genre_id);
            return View(cOURANTLITTERAIRE);
        }

        // GET: Courantlitteraire/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURANTLITTERAIRE cOURANTLITTERAIRE = db.COURANTLITTERAIRE.Find(id);
            if (cOURANTLITTERAIRE == null)
            {
                return HttpNotFound();
            }
            ViewBag.genre_id = new SelectList(db.GENRE, "genre_id", "libelle", cOURANTLITTERAIRE.genre_id);
            return View(cOURANTLITTERAIRE);
        }

        // POST: Courantlitteraire/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "commentlitteraire_id,libelle,genre_id")] COURANTLITTERAIRE cOURANTLITTERAIRE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOURANTLITTERAIRE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.genre_id = new SelectList(db.GENRE, "genre_id", "libelle", cOURANTLITTERAIRE.genre_id);
            return View(cOURANTLITTERAIRE);
        }

        // GET: Courantlitteraire/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURANTLITTERAIRE cOURANTLITTERAIRE = db.COURANTLITTERAIRE.Find(id);
            if (cOURANTLITTERAIRE == null)
            {
                return HttpNotFound();
            }
            return View(cOURANTLITTERAIRE);
        }

        // POST: Courantlitteraire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COURANTLITTERAIRE cOURANTLITTERAIRE = db.COURANTLITTERAIRE.Find(id);
            db.COURANTLITTERAIRE.Remove(cOURANTLITTERAIRE);
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
