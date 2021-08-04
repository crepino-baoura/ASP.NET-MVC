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
    public class EditeurController : Controller
    {
        private BD_GESTION_BIBLIOEntities1 db = new BD_GESTION_BIBLIOEntities1();

        // GET: Editeur
        public ActionResult Index()
        {
            return View(db.EDITEUR.ToList());
        }

        // GET: Editeur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EDITEUR eDITEUR = db.EDITEUR.Find(id);
            if (eDITEUR == null)
            {
                return HttpNotFound();
            }
            return View(eDITEUR);
        }

        // GET: Editeur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editeur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "editeur_id,libelle,adresse,tel,pays")] EDITEUR eDITEUR)
        {
            if (ModelState.IsValid)
            {
                db.EDITEUR.Add(eDITEUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eDITEUR);
        }

        // GET: Editeur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EDITEUR eDITEUR = db.EDITEUR.Find(id);
            if (eDITEUR == null)
            {
                return HttpNotFound();
            }
            return View(eDITEUR);
        }

        // POST: Editeur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "editeur_id,libelle,adresse,tel,pays")] EDITEUR eDITEUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eDITEUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eDITEUR);
        }

        // GET: Editeur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EDITEUR eDITEUR = db.EDITEUR.Find(id);
            if (eDITEUR == null)
            {
                return HttpNotFound();
            }
            return View(eDITEUR);
        }

        // POST: Editeur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EDITEUR eDITEUR = db.EDITEUR.Find(id);
            db.EDITEUR.Remove(eDITEUR);
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
