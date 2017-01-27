using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpeedRacing.Models;
using SpeedRacing.Models.Komis;

namespace SpeedRacing.Controllers.Admin.Komis
{
    [Authorize(Roles = "Administrator")]
    public class KomisKategoriaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: KomisKategoria
        public ActionResult Index()
        {
            return View(db.KomisKategoria.ToList());
        }

        // GET: KomisKategoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KomisKategoria komisKategoria = db.KomisKategoria.Find(id);
            if (komisKategoria == null)
            {
                return HttpNotFound();
            }
            return View(komisKategoria);
        }

        // GET: KomisKategoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KomisKategoria/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KomisKategoriaId,Nazwa,Opis,CzyAktywny")] KomisKategoria komisKategoria)
        {
            if (ModelState.IsValid)
            {
                db.KomisKategoria.Add(komisKategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(komisKategoria);
        }

        // GET: KomisKategoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KomisKategoria komisKategoria = db.KomisKategoria.Find(id);
            if (komisKategoria == null)
            {
                return HttpNotFound();
            }
            return View(komisKategoria);
        }

        // POST: KomisKategoria/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KomisKategoriaId,Nazwa,Opis,CzyAktywny")] KomisKategoria komisKategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(komisKategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(komisKategoria);
        }

        // GET: KomisKategoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KomisKategoria komisKategoria = db.KomisKategoria.Find(id);
            if (komisKategoria == null)
            {
                return HttpNotFound();
            }
            return View(komisKategoria);
        }

        // POST: KomisKategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KomisKategoria komisKategoria = db.KomisKategoria.Find(id);
            db.KomisKategoria.Remove(komisKategoria);
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
