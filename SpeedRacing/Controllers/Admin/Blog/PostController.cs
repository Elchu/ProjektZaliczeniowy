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
using System.IO;

namespace SpeedRacing.Controllers.Admin.Blog
{
    [Authorize(Roles = "Administrator")]
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Post
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Kategorie);
            return View(posts.ToList());
        }

        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }                                                

        // GET: Post/Create
        public ActionResult Create()
        {
            ViewBag.KategorieId = new SelectList(db.Kategories, "KategorieId", "Nazwa");
            return View();
        }

        // POST: Post/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "PostyId,Tytul,KrotkiOpis,Tresc,Opis,PrzyjazdyOpis,DataPublikacji,Autor,DataModyfikacji,CzyOpublikowany,Zdjecie,KategorieId")] Post post)
        {
            if (ModelState.IsValid)
            {
                Upload(Request.Files[0]);
                Post nowyPost = new Post();
                nowyPost.Tytul = post.Tytul;
                nowyPost.KrotkiOpis = post.KrotkiOpis;
                nowyPost.Tresc = post.Tresc;
                nowyPost.Opis = post.Opis;
                nowyPost.PrzyjazdyOpis = post.PrzyjazdyOpis;
                nowyPost.DataPublikacji = post.DataPublikacji;
                nowyPost.Autor = post.Autor;
                nowyPost.DataModyfikacji = post.DataModyfikacji;
                nowyPost.CzyOpublikowany = post.CzyOpublikowany;
                nowyPost.Zdjecie = Request.Files[0] != null ? Request.Files[0].FileName : "";
                nowyPost.KategorieId = post.KategorieId;
                db.Posts.Add(nowyPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategorieId = new SelectList(db.Kategories, "KategorieId", "Nazwa", post.KategorieId);
            return View(post);
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategorieId = new SelectList(db.Kategories, "KategorieId", "Nazwa", post.KategorieId);
            return View(post);
        }

        // POST: Post/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "PostyId,Tytul,KrotkiOpis,Tresc,Opis,PrzyjazdyOpis,DataPublikacji,Autor,DataModyfikacji,CzyOpublikowany,Zdjecie,KategorieId")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategorieId = new SelectList(db.Kategories, "KategorieId", "Nazwa", post.KategorieId);
            return View(post);
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
        public void Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/images/Blog/"), fileName);
                file.SaveAs(path);
            }
        }
        #endregion //Helpers
    }
}
