using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpeedRacing.Models;
using SpeedRacing.Models.Blog;

namespace SpeedRacing.Controllers.Admin.Blog
{
    [Authorize(Roles = "Administrator")]
    public class KategorieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Kategorie
        public ActionResult Index()
        {
            return View(db.Kategories.ToList());
        }

        // GET: Kategorie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorie kategorie = db.Kategories.Find(id);
            if (kategorie == null)
            {
                return HttpNotFound();
            }
            return View(kategorie);
        }

        // GET: Kategorie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategorie/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KategorieId,Nazwa,PrzyjaznaNazwa,Opis,DataUtworzenia,CzyOpublikowany")] Kategorie kategorie)
        {
            if (ModelState.IsValid)
            {
                db.Kategories.Add(kategorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategorie);
        }

        // GET: Kategorie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorie kategorie = db.Kategories.Find(id);
            if (kategorie == null)
            {
                return HttpNotFound();
            }
            return View(kategorie);
        }

        // POST: Kategorie/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KategorieId,Nazwa,PrzyjaznaNazwa,Opis,DataUtworzenia,CzyOpublikowany")] Kategorie kategorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategorie);
        }

        // GET: Kategorie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorie kategorie = db.Kategories.Find(id);
            if (kategorie == null)
            {
                return HttpNotFound();
            }
            return View(kategorie);
        }

        // POST: Kategorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategorie kategorie = db.Kategories.Find(id);
            db.Kategories.Remove(kategorie);
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
