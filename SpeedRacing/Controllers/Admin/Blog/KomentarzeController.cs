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
    public class KomentarzeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Komentarze
        public ActionResult Index()
        {
            var komentarzes = db.Komentarzes.Include(k => k.Post);
            return View(komentarzes.ToList());
        }

        // GET: Komentarze/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentarze komentarze = db.Komentarzes.Find(id);
            if (komentarze == null)
            {
                return HttpNotFound();
            }
            return View(komentarze);
        }

        // GET: Komentarze/Create
        public ActionResult Create()
        {
            ViewBag.PostyId = new SelectList(db.Posts, "PostyId", "Tytul");
            return View();
        }

        // POST: Komentarze/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KomentarzeId,Tresc,DataPublikacji,Ip,Uzytkownik,Nick,CzyOpublikowany,PostyId")] Komentarze komentarze)
        {
            if (ModelState.IsValid)
            {
                db.Komentarzes.Add(komentarze);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostyId = new SelectList(db.Posts, "PostyId", "Tytul", komentarze.PostyId);
            return View(komentarze);
        }

        // GET: Komentarze/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentarze komentarze = db.Komentarzes.Find(id);
            if (komentarze == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostyId = new SelectList(db.Posts, "PostyId", "Tytul", komentarze.PostyId);
            return View(komentarze);
        }

        // POST: Komentarze/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KomentarzeId,Tresc,DataPublikacji,Ip,Uzytkownik,Nick,CzyOpublikowany,PostyId")] Komentarze komentarze)
        {
            if (ModelState.IsValid)
            {
                db.Entry(komentarze).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostyId = new SelectList(db.Posts, "PostyId", "Tytul", komentarze.PostyId);
            return View(komentarze);
        }

        // GET: Komentarze/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentarze komentarze = db.Komentarzes.Find(id);
            if (komentarze == null)
            {
                return HttpNotFound();
            }
            return View(komentarze);
        }

        // POST: Komentarze/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Komentarze komentarze = db.Komentarzes.Find(id);
            db.Komentarzes.Remove(komentarze);
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
