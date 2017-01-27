using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpeedRacing.Models;

namespace SpeedRacing.Controllers.Admin.Slownik
{
    [Authorize(Roles = "Administrator")]
    public class ModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Model
        public ActionResult Index()
        {
            var model = db.Model.Include(m => m.Marka);
            return View(model.ToList());
        }

        // GET: Model/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Model/Create
        public ActionResult Create()
        {
            ViewBag.MarkaId = new SelectList(db.Marka, "MarkaId", "Nazwa");
            return View();
        }

        // POST: Model/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelId,Nazwa,CzyAktywny,MarkaId")] Model model)
        {
            if (ModelState.IsValid)
            {
                db.Model.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarkaId = new SelectList(db.Marka, "MarkaId", "Nazwa", model.MarkaId);
            return View(model);
        }

        // GET: Model/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarkaId = new SelectList(db.Marka, "MarkaId", "Nazwa", model.MarkaId);
            return View(model);
        }

        // POST: Model/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModelId,Nazwa,CzyAktywny,MarkaId")] Model model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarkaId = new SelectList(db.Marka, "MarkaId", "Nazwa", model.MarkaId);
            return View(model);
        }

        // GET: Model/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model model = db.Model.Find(id);
            db.Model.Remove(model);
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
