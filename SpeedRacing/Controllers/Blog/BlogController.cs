using PagedList;
using SpeedRacing.Models;
using SpeedRacing.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpeedRacing.Controllers.Blog
{
    
    public class BlogController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? page)
        {
            const int pagesize = 5;

            if (Request.HttpMethod != "GET")
                page = 1;

            int pageNumber = (page ?? 1);
            var posty = db.Posts.Where(p => p.CzyOpublikowany).ToList().OrderByDescending(a => a.PostyId);

            return View(posty.ToPagedList(pageNumber, pagesize));
        }

        public ActionResult Szczegoly(int id)
        {
            var post = db.Posts.Find(id);

            return View(post);

        }

        [HttpPost]
        public ActionResult DodajKomentarz(FormCollection formCollection)
        {
            if (formCollection["Nick"] != "" && formCollection["Wiadomosc"] != "")
            {
                Komentarze nowyKomentarz = new Komentarze();
                nowyKomentarz.Nick = formCollection["Nick"];
                nowyKomentarz.Tresc = formCollection["Wiadomosc"];
                nowyKomentarz.DataPublikacji = DateTime.Now;
                nowyKomentarz.PostyId = Convert.ToInt32(formCollection["PostyId"]);

                db.Komentarzes.Add(nowyKomentarz);
                db.SaveChanges();

                ViewBag.Error = string.Empty;
                return View("Szczegoly", db.Posts.Find(Convert.ToInt32(formCollection["PostyId"])));
            }

            ViewBag.Error = "Wprowadź poprawnie dane";
            return View("Szczegoly", db.Posts.Find(Convert.ToInt32(formCollection["PostyId"])));
        }


    }
}