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
    public class AuteurController : Controller
    {
        private BD_GESTION_BIBLIOEntities1 db = new BD_GESTION_BIBLIOEntities1();

        // GET: Auteur
        public ActionResult Index()
        {
            return View(db.AUTEUR.ToList());
        }

        // GET: Auteur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTEUR aUTEUR = db.AUTEUR.Find(id);
            if (aUTEUR == null)
            {
                return HttpNotFound();
            }
            return View(aUTEUR);
        }

        // GET: Auteur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auteur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "auteur_id,nom,prenom,tel,pays,adresse")] AUTEUR aUTEUR)
        {
            if (ModelState.IsValid)
            {
                db.AUTEUR.Add(aUTEUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aUTEUR);
        }

        // GET: Auteur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTEUR aUTEUR = db.AUTEUR.Find(id);
            if (aUTEUR == null)
            {
                return HttpNotFound();
            }
            return View(aUTEUR);
        }

        // POST: Auteur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "auteur_id,nom,prenom,tel,pays,adresse")] AUTEUR aUTEUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aUTEUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aUTEUR);
        }

        // GET: Auteur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTEUR aUTEUR = db.AUTEUR.Find(id);
            if (aUTEUR == null)
            {
                return HttpNotFound();
            }
            return View(aUTEUR);
        }

        // POST: Auteur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AUTEUR aUTEUR = db.AUTEUR.Find(id);
            db.AUTEUR.Remove(aUTEUR);
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
