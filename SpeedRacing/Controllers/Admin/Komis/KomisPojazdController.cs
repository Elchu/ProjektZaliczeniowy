using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpeedRacing.Models;
using SpeedRacing.Models.Komis;

namespace SpeedRacing.Controllers.Admin.Komis
{
    [Authorize(Roles = "Administrator")]
    public class KomisPojazdController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: KomisPojazd
        public ActionResult Index()
        {
            var komisPojazd = db.KomisPojazd.Include(k => k.KomisKategoria);
            return View(komisPojazd.ToList());
        }

        // GET: KomisPojazd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KomisPojazd komisPojazd = db.KomisPojazd.Find(id);
            if (komisPojazd == null)
            {
                return HttpNotFound();
            }
            return View(komisPojazd);
        }

        // GET: KomisPojazd/Create
        public ActionResult Create()
        {
            ViewBag.KomisKategoriaId = new SelectList(db.KomisKategoria, "KomisKategoriaId", "Nazwa");
            ViewBag.UserId = db.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.Id, Text = uu.UserName }).ToList();
            return View();
        }

        // POST: KomisPojazd/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KomisPojazdId,Marka,Model,Rok,Kilometry,TypNadwozia,SkrzyniaBiegow,CenaProponowana,Rabat,CenaSprzedazy,DataDodania,DataModyfikacji,UserId,Adres,KrotkiOpis,Uwagi,Tresc,CzySprzedany,CzyPoszukiwany,CzyZarezerwowany,CzyNaSprzedaz,CzyWycofany,CzyAktywny,Wyrozniony,Promocja,Wyprzedaz,Zdjecie1,Zdjecie2,Zdjecie3,Zdjecie4,KomisKategoriaId")] KomisPojazd komisPojazd)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files[0] != null)
                {
                    komisPojazd.Zdjecie1 = Path.GetFileName(Request.Files[0].FileName);
                    Upload(Request.Files[0]);
                }

                if (Request.Files[1] != null)
                {
                    Upload(Request.Files[1]);
                    komisPojazd.Zdjecie2 = Path.GetFileName(Request.Files[1].FileName);
                }

                if (Request.Files[2] != null)
                {
                    Upload(Request.Files[2]);
                    komisPojazd.Zdjecie3 = Path.GetFileName(Request.Files[2].FileName);
                }

                if (Request.Files[3] != null && komisPojazd.CzyNaSprzedaz)
                {
                    Upload(Request.Files[3]);
                    komisPojazd.Zdjecie4 = Path.GetFileName(Request.Files[3].FileName);
                }

                db.KomisPojazd.Add(komisPojazd);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.UserId = db.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.Id, Text = uu.UserName }).ToList();
            ViewBag.KomisKategoriaId = new SelectList(db.KomisKategoria, "KomisKategoriaId", "Nazwa", komisPojazd.KomisKategoriaId);
            return View(komisPojazd);
        }

        // GET: KomisPojazd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KomisPojazd komisPojazd = db.KomisPojazd.Find(id);
            if (komisPojazd == null)
            {
                return HttpNotFound();
            }
            ViewBag.KomisKategoriaId = new SelectList(db.KomisKategoria, "KomisKategoriaId", "Nazwa", komisPojazd.KomisKategoriaId);
            return View(komisPojazd);
        }

        // POST: KomisPojazd/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KomisPojazdId,Marka,Model,Rok,Kilometry,TypNadwozia,SkrzyniaBiegow,CenaProponowana,Rabat,CenaSprzedazy,DataDodania,DataModyfikacji,UserId,Adres,KrotkiOpis,Uwagi,Tresc,CzySprzedany,CzyPoszukiwany,CzyZarezerwowany,CzyNaSprzedaz,CzyWycofany,CzyAktywny,Wyrozniony,Promocja,Wyprzedaz,Zdjecie1,Zdjecie2,Zdjecie3,Zdjecie4,KomisKategoriaId")] KomisPojazd komisPojazd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(komisPojazd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KomisKategoriaId = new SelectList(db.KomisKategoria, "KomisKategoriaId", "Nazwa", komisPojazd.KomisKategoriaId);
            return View(komisPojazd);
        }

        // GET: KomisPojazd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KomisPojazd komisPojazd = db.KomisPojazd.Find(id);
            if (komisPojazd == null)
            {
                return HttpNotFound();
            }
            return View(komisPojazd);
        }

        // POST: KomisPojazd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KomisPojazd komisPojazd = db.KomisPojazd.Find(id);
            db.KomisPojazd.Remove(komisPojazd);
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

        #region Helpers
        /// <summary>
        /// Funkcja uploaduje zdjecia
        /// </summary>
        /// <param name="file">Przyjmuje parametr pochodzacy z formularza jako Request.Files[index]</param>
        ///<param name="gdzieKopiowac">Przyjmuje parametr, ktory okresla gdzie zostanie zdjecie uploadowane - poszukuje, sprzedaje</param>
        public void Upload(HttpPostedFileBase file, string gdzieKopiowac)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = string.Empty;
                
                if(gdzieKopiowac.Equals("poszukuje"))
                    path = Path.Combine(Server.MapPath("~/images/Komis/Poszukuje"), fileName);
                else if(gdzieKopiowac.Equals("sprzedaje"))
                    path = Path.Combine(Server.MapPath("~/images/Komis/Sprzedaj"), fileName);

                if(path != string.Empty)
                    file.SaveAs(path);
            }
        }
        /// <summary>
        /// Funkcja uploaduje zdjecia
        /// </summary>
        /// <param name="file">Przyjmuje parametr pochodzacy z formularza jako Request.Files[index]</param>
        public void Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/images/Komis/ZdjeciaSamochodow"), fileName);
                
                file.SaveAs(path);
            }
        }
        #endregion //Helpers
    }
}
