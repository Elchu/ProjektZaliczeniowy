using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpeedRacing.Models;

namespace SpeedRacing.Controllers.Komis
{

    public class KomisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Komis
        public ActionResult Index()
        {
            return View(db.KomisKategoria.ToList());
        }

        public ActionResult Przegladaj(int? id)
        {
            //tutaj przyjmiemy jakis parametr i wyswietlimy odpowiednia kategorie z samochodami
            var listaPojazdow = db.KomisPojazd.Where(k => (k.KomisKategoriaId == id && k.CzyNaSprzedaz)).ToList();

                return View(listaPojazdow);
                
        }

        public ActionResult Szczegoly(int? id)
        {
            return View(db.KomisPojazd.Find(id));
        }

        public ActionResult Index2()
        {
            return View(db.KomisKategoria.ToList());
        }

        public ActionResult Poszukuje(int? id)
        {
            var listaPojazdow = db.KomisPojazd.Where(k => (k.KomisKategoriaId == id && k.CzyPoszukiwany)).ToList();
            return View(listaPojazdow);
        }

        public ActionResult PoszukujeSzczegoly(int? id)
        {
            return View(db.KomisPojazd.Find(id));
        }

        public ActionResult Skup()
        {
            return View();
        }
    }
}