using SpeedRacing.BussinesLogic;
using SpeedRacing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SpeedRacing.ViewModel;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;


namespace SpeedRacing.Controllers.Admin
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        #region BLOG

        public ActionResult PrzegladajPosty()
        {
            var posts = db.Posts.Include(p => p.Kategorie);
            return View("../Post/Index", posts.ToList());
        }

        #endregion //BLOG

        #region NAPRAWA

        public ActionResult ListaSamochodowDoNaprawy()
        {
            var samochodyDoNaprawy = db.Naprawa.Where(n => !n.CzyNaprawiony).OrderByDescending(n => n.NaprawaId).ToList();

            if (samochodyDoNaprawy.Any())
            {
                var szczegolowaListaNaprawKlienta = new List<DaneNaprawy>();

                foreach (var item in samochodyDoNaprawy)
                {
                    szczegolowaListaNaprawKlienta.Add(
                        new DaneNaprawy
                        {
                            DaneNaprawyId = item.NaprawaId,
                            NazwiskoKlienta = item.Klient.Imie + " " + item.Klient.Nazwisko,
                            DaneSamochodu = item.Samochod.Marka.Nazwa + " " + item.Samochod.Model.Nazwa,
                            DanePracownika = item.Pracownik.Imie + " " + item.Pracownik.Nazwisko,
                            DataRozpoczecia = item.DataRozpoczecia,
                            DataZakonczenia = item.DataZakonczenia,
                            OpisUsterki = item.OpisUsterki,
                            OpisNaprawy = item.OpisNaprawy,
                            Cena = item.Cena,
                            CzyNaprawiac = item.CzyNaprawiac,
                            CzyNaprawiono = item.CzyNaprawiony,
                            CzyAktywny = item.CzyAktywny
                        }
                    );
                }

                return View(szczegolowaListaNaprawKlienta);
            }

            return View("Index");
        }

        public ActionResult EdytujSamochodDoNaprawy(int id)
        {
            if (id != null)
            {
                var znajdzNaprawe = db.Naprawa.FirstOrDefault(n => n.NaprawaId == id);
                
                if (znajdzNaprawe != null)
                {
                    ViewBag.MarkaId = new SelectList(db.Marka, "MarkaId", "Nazwa", znajdzNaprawe.Samochod.MarkaId);
                    ViewBag.ModelId = new SelectList(db.Model, "ModelId", "Nazwa", znajdzNaprawe.Samochod.ModelId);
                    ViewBag.PojemnoscId = new SelectList(db.Pojemnosc, "PojemnoscId", "Nazwa", znajdzNaprawe.Samochod.Pojemnosc.PojemnoscId);
                    ViewBag.RodzajNadwoziaId = new SelectList(db.RodzajNadwozia, "RodzajNadwoziaId", "Nazwa", znajdzNaprawe.Samochod.RodzajNadwozia.RodzajNadwoziaId);
                    ViewBag.RodzajPaliwaId = new SelectList(db.RodzajPaliwa, "RodzajPaliwaId", "Nazwa", znajdzNaprawe.Samochod.RodzajPaliwa.RodzajPaliwaId);
                    ViewBag.RokProdukcjiId = new SelectList(db.RokProdukcji, "RokProdukcjiId", "Nazwa", znajdzNaprawe.Samochod.RokProdukcji.RokProdukcjiId);
                    ViewBag.PracownikId = new SelectList(db.Pracownik, "PracownikId", "Nazwisko", znajdzNaprawe.Pracownik.PracownikId);
                    return View(znajdzNaprawe);
                }
            }

            return RedirectToAction("ListaSamochodowDoNaprawy");
        }

        [HttpPost]
        public ActionResult EdytujSamochodDoNaprawy(Models.Naprawa naprawa)
        {
            var edytujNaprawe = db.Naprawa.Single(n=>n.NaprawaId == naprawa.NaprawaId);

            edytujNaprawe.PracownikId = naprawa.PracownikId;
            edytujNaprawe.DataRozpoczecia = naprawa.DataRozpoczecia;
            edytujNaprawe.DataZakonczenia = naprawa.DataZakonczenia;
            edytujNaprawe.OpisNaprawy = naprawa.OpisNaprawy;
            edytujNaprawe.Cena = naprawa.Cena;
            edytujNaprawe.CzyNaprawiony = naprawa.CzyNaprawiony;
            edytujNaprawe.CzyAktywny = naprawa.CzyAktywny;

            db.Entry(edytujNaprawe).State = EntityState.Modified;
            db.SaveChanges(); 

            return RedirectToAction("ListaSamochodowDoNaprawy");
        }


        public ActionResult ListaSamochodowNaprawionych()
        {
            var samochodyDoNaprawy = db.Naprawa.Where(n => n.CzyNaprawiony).OrderByDescending(n => n.NaprawaId).ToList();

            if (samochodyDoNaprawy.Any())
            {
                var szczegolowaListaNaprawKlienta = new List<DaneNaprawy>();

                foreach (var item in samochodyDoNaprawy)
                {
                    szczegolowaListaNaprawKlienta.Add(
                        new DaneNaprawy
                        {
                            DaneNaprawyId = item.NaprawaId,
                            NazwiskoKlienta = item.Klient.Imie + " " + item.Klient.Nazwisko,
                            DaneSamochodu = item.Samochod.Marka.Nazwa + " " + item.Samochod.Model.Nazwa,
                            DanePracownika = item.Pracownik.Imie + " " + item.Pracownik.Nazwisko,
                            DataRozpoczecia = item.DataRozpoczecia,
                            DataZakonczenia = item.DataZakonczenia,
                            OpisUsterki = item.OpisUsterki,
                            OpisNaprawy = item.OpisNaprawy,
                            Cena = item.Cena,
                            CzyNaprawiac = item.CzyNaprawiac,
                            CzyNaprawiono = item.CzyNaprawiony,
                            CzyAktywny = item.CzyAktywny
                        }
                    );
                }

                return View(szczegolowaListaNaprawKlienta);
            }

            return View("Index");
        }

        #endregion //NAPRAWA

        #region Autoryzacja

        public ActionResult ListaRol()
        {
            var roles = db.Roles.ToList();
            return View(roles);
        }

        public ActionResult UtworzRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UtworzRole(FormCollection collection)
        {
            try
            {
                db.Roles.Add(
                    new IdentityRole()//Microsoft.AspNet.Identity.EntityFramework.
                    {
                        Name = collection["RoleName"]
                    });
                db.SaveChanges();
                ViewBag.ResultMessage = "Rola utworzona pomyślnie";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EdytujRole(string RoleName)
        {
            
            var role = db.Roles.FirstOrDefault(r => r.Name.Equals(RoleName,StringComparison.CurrentCultureIgnoreCase));
            
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EdytujRole(IdentityRole role)
        {
            try
            {
                var isRole = db.Roles.FirstOrDefault(r => r.Name.Equals(role.Name,StringComparison.CurrentCultureIgnoreCase));
                if (isRole == null)
                {
                    db.Entry(role).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ListaRol");
                }
                else
                {
                    ViewBag.Blad = "Rola o takiej nazwie już istnieje";
                    return View(role);
                }
            }
            catch
            {
                return View();

            }
        }

        public ActionResult DodajRoleDoUzytkownika()
        {
            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr =>new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            var userList = db.Users.OrderBy(u=>u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            
            ViewBag.Roles = list;
            ViewBag.Users = userList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DodajRoleDoUzytkownika(string UserName, string RoleName)
        {
            ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(UserName,StringComparison.InvariantCultureIgnoreCase));
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            
            um.AddToRole(user.Id, RoleName);

            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr =>new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            
            ViewBag.Roles = list;
            ViewBag.Powterdzenie = "Rola została dodana";
            
            return RedirectToAction("ListaRol");
        }

        public ActionResult WyswietlRoleUzytkownika()
        {
            var userList = db.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WyswietlRoleUzytkownika(string UserName)
        {
            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                           new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }
                           ).ToList();
            ViewBag.Roles = list;

            var userList = db.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;

            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(UserName,StringComparison.CurrentCultureIgnoreCase));
                var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>
                (new ApplicationDbContext()));

                ViewBag.RolesForThisUser = um.GetRoles(user.Id);
            }
            return View("WyswietlRoleUzytkownika");
        }

        public ActionResult UsunRoleUzytkownikowi()
        {
            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            var userList = db.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();

            ViewBag.Roles = list;
            ViewBag.Users = userList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsunRoleUzytkownikowi(string UserName, string RoleName)
        {

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase));

            if (um.IsInRole(user.Id, RoleName))
            {
                um.RemoveFromRole(user.Id, RoleName);
                ViewBag.ResultSuccess = "Rola została usunięta!";
            }
            else
            {
                ViewBag.ResultWarning = "Ten użytkownik nie posiada takiej roli.";
            }

            // prepopulat roles for the view dropdown

            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem{Value = rr.Name.ToString(), Text = rr.Name }).ToList();

            ViewBag.Roles = list;

            return RedirectToAction("ListaRol");

        }
        #endregion //Autoryzacja

        #region Komis

        #endregion //Komis

        #region Statystyki

        public ActionResult Statystyka()
        {
            Statystyki statystyka = new Statystyki();

            statystyka.IloscKomentarzy = BStatystyki.IloscWszystkichKomentarzy();
            statystyka.IloscPostow = BStatystyki.IloscWszystkichPostow();
            statystyka.IloscSamochodowNaSprzedaz = BStatystyki.IloscSamochodowNaSprzedaz();
            statystyka.IloscSamochodowPoszukiwanych = BStatystyki.IloscSamochodowPoszukiwanych();
            statystyka.IloscSamochodowSprzedanych = BStatystyki.IloscSamochodSprzedanych();
            statystyka.IloscUzytkownikowWSerwisie = BStatystyki.IloscUzytkownikow();

            return View(statystyka);
        }
        #endregion
    }
}