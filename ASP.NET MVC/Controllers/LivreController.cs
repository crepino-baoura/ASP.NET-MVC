using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC.Models;
using System.IO;

namespace ASP.NET_MVC.Controllers
{
    public class LivreController : Controller
    {
        private BD_GESTION_BIBLIOEntities1 db = new BD_GESTION_BIBLIOEntities1();

        // GET: Livre
        public ActionResult Index()
        {
            var lIVRE = db.LIVRE.Include(l => l.AUTEUR1).Include(l => l.COURANTLITTERAIRE).Include(l => l.EDITEUR).Include(l => l.GENRE);
            return View(lIVRE.ToList());
        }

        // GET: Livre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIVRE lIVRE = db.LIVRE.Find(id);
            if (lIVRE == null)
            {
                return HttpNotFound();
            }
            return View(lIVRE);
        }

        // GET: Livre/Create
        public ActionResult Create()
        {
            ViewBag.AUTEUR = new SelectList(db.AUTEUR, "auteur_id", "nom");
            ViewBag.commentlitteraire_id = new SelectList(db.COURANTLITTERAIRE, "commentlitteraire_id", "libelle");
            ViewBag.editeur_id = new SelectList(db.EDITEUR, "editeur_id", "libelle");
            ViewBag.genre_id = new SelectList(db.GENRE, "genre_id", "libelle");
            return View();
        }

        // POST: Livre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "livre_id,libelle,url,image_livre,date_edit,genre_id,commentlitteraire_id,AUTEUR,editeur_id")] LIVRE lIVRE)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Fichier"), filename);
                        file.SaveAs(path);

                        lIVRE.url = filename;
                        lIVRE.image_livre = "/Fichier";  
                    }
                }

                db.LIVRE.Add(lIVRE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AUTEUR = new SelectList(db.AUTEUR, "auteur_id", "nom", lIVRE.AUTEUR);
            ViewBag.commentlitteraire_id = new SelectList(db.COURANTLITTERAIRE, "commentlitteraire_id", "libelle", lIVRE.commentlitteraire_id);
            ViewBag.editeur_id = new SelectList(db.EDITEUR, "editeur_id", "libelle", lIVRE.editeur_id);
            ViewBag.genre_id = new SelectList(db.GENRE, "genre_id", "libelle", lIVRE.genre_id);
            return View(lIVRE);
        }

        // GET: Livre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIVRE lIVRE = db.LIVRE.Find(id);
            if (lIVRE == null)
            {
                return HttpNotFound();
            }
            ViewBag.AUTEUR = new SelectList(db.AUTEUR, "auteur_id", "nom", lIVRE.AUTEUR);
            ViewBag.commentlitteraire_id = new SelectList(db.COURANTLITTERAIRE, "commentlitteraire_id", "libelle", lIVRE.commentlitteraire_id);
            ViewBag.editeur_id = new SelectList(db.EDITEUR, "editeur_id", "libelle", lIVRE.editeur_id);
            ViewBag.genre_id = new SelectList(db.GENRE, "genre_id", "libelle", lIVRE.genre_id);
            return View(lIVRE);
        }

        // POST: Livre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "livre_id,libelle,url,image_livre,date_edit,genre_id,commentlitteraire_id,AUTEUR,editeur_id")] LIVRE lIVRE)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Fichier"), filename);
                        file.SaveAs(path);

                        lIVRE.url = filename;
                        lIVRE.image_livre = "/Fichier";
                    }
                }
                db.Entry(lIVRE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AUTEUR = new SelectList(db.AUTEUR, "auteur_id", "nom", lIVRE.AUTEUR);
            ViewBag.commentlitteraire_id = new SelectList(db.COURANTLITTERAIRE, "commentlitteraire_id", "libelle", lIVRE.commentlitteraire_id);
            ViewBag.editeur_id = new SelectList(db.EDITEUR, "editeur_id", "libelle", lIVRE.editeur_id);
            ViewBag.genre_id = new SelectList(db.GENRE, "genre_id", "libelle", lIVRE.genre_id);
            return View(lIVRE);
        }

        // GET: Livre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIVRE lIVRE = db.LIVRE.Find(id);
            if (lIVRE == null)
            {
                return HttpNotFound();
            }
            return View(lIVRE);
        }

        // POST: Livre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIVRE lIVRE = db.LIVRE.Find(id);
            db.LIVRE.Remove(lIVRE);
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
