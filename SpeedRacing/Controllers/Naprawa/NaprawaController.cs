using System.Runtime.InteropServices.ComTypes;
using SpeedRacing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using SpeedRacing.ViewModel;

namespace SpeedRacing.Controllers.Naprawa
{
    [Authorize]
    public class NaprawaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return RedirectToAction("ListaSamochodow");
        }

        public ActionResult DaneUzytkownika()
        {
            //string userLogin = User.Identity.GetUserId();

            //var uzytkownik = db.Klient.FirstOrDefault(u => u.LoginId.Equals(userLogin));

            var uzytkownik = PobierzUzytkownika(PobierzLoginUzytkownika());

            return View(uzytkownik);
        }

        [HttpPost]
        public ActionResult DaneUzytkownika(Klient klient)
        {
            //string userLogin = User.Identity.GetUserId();

            //var uzytkownik = db.Klient.FirstOrDefault(u => u.LoginId.Equals(userLogin));

            var uzytkownik = PobierzUzytkownika(PobierzLoginUzytkownika());

            if (uzytkownik == null)
            {
                var nowyUzytkownik = new Klient();
                nowyUzytkownik.Imie = klient.Imie;
                nowyUzytkownik.Kod = klient.Kod;
                nowyUzytkownik.LoginId = uzytkownik.LoginId;
                nowyUzytkownik.Miasto = klient.Miasto;
                nowyUzytkownik.Nazwisko = klient.Nazwisko;
                nowyUzytkownik.NrDomu = klient.NrDomu;
                nowyUzytkownik.NumerMieszkania = klient.NumerMieszkania;
                nowyUzytkownik.Telefon = klient.Telefon;
                nowyUzytkownik.Email = klient.Email;
                nowyUzytkownik.Ulica = klient.Ulica;
                nowyUzytkownik.CzyAktywny = true;

                db.Klient.Add(nowyUzytkownik);
            }
            else
            {
                uzytkownik.Imie = klient.Imie;
                uzytkownik.Kod = klient.Kod;
                uzytkownik.LoginId = uzytkownik.LoginId;
                uzytkownik.Miasto = klient.Miasto;
                uzytkownik.Nazwisko = klient.Nazwisko;
                uzytkownik.NrDomu = klient.NrDomu;
                uzytkownik.NumerMieszkania = klient.NumerMieszkania;
                uzytkownik.Telefon = klient.Telefon;
                uzytkownik.Email = klient.Email;
                uzytkownik.Ulica = klient.Ulica;
                uzytkownik.CzyAktywny = true;

                db.Entry(uzytkownik).State = EntityState.Modified;
            }

            db.SaveChanges();
            ViewBag.Success = "Dane zostały poprawie zapisane";
            return View();
        }


        public ActionResult DaneSamochodu()
        {
            ViewBag.MarkaId = new SelectList(db.Marka, "MarkaId", "Nazwa");
            ViewBag.ModelId = new SelectList(db.Model, "ModelId", "Nazwa");
            ViewBag.PojemnoscId = new SelectList(db.Pojemnosc, "PojemnoscId", "Nazwa");
            ViewBag.RodzajNadwoziaId = new SelectList(db.RodzajNadwozia, "RodzajNadwoziaId", "Nazwa");
            ViewBag.RodzajPaliwaId = new SelectList(db.RodzajPaliwa, "RodzajPaliwaId", "Nazwa");
            ViewBag.RokProdukcjiId = new SelectList(db.RokProdukcji, "RokProdukcjiId", "Nazwa");

            return View();
        }

        [HttpPost]
        public ActionResult DaneSamochodu(Samochod daneSamochodu)
        {
            ViewBag.MarkaId = new SelectList(db.Marka, "MarkaId", "Nazwa");
            ViewBag.ModelId = new SelectList(db.Model, "ModelId", "Nazwa");
            ViewBag.PojemnoscId = new SelectList(db.Pojemnosc, "PojemnoscId", "Nazwa");
            ViewBag.RodzajNadwoziaId = new SelectList(db.RodzajNadwozia, "RodzajNadwoziaId", "Nazwa");
            ViewBag.RodzajPaliwaId = new SelectList(db.RodzajPaliwa, "RodzajPaliwaId", "Nazwa");
            ViewBag.RokProdukcjiId = new SelectList(db.RokProdukcji, "RokProdukcjiId", "Nazwa");

            //string userLogin = User.Identity.GetUserId();

            //var uzytkownik = db.Klient.FirstOrDefault(u => u.LoginId.Equals(userLogin));

            var uzytkownik = PobierzUzytkownika(PobierzLoginUzytkownika());

            if (uzytkownik != null)
            {
                var samochod = new Samochod();
                samochod.KlientId = uzytkownik.KlientId;
                samochod.NrRejestracyjny = daneSamochodu.NrRejestracyjny;
                samochod.MarkaId = daneSamochodu.MarkaId;
                samochod.ModelId = daneSamochodu.ModelId;
                samochod.RodzajNadwoziaId = daneSamochodu.RodzajNadwoziaId;
                samochod.RodzajPaliwaId = daneSamochodu.RodzajPaliwaId;
                samochod.RokProdukcjiId = daneSamochodu.RokProdukcjiId;
                samochod.PojemnoscId = daneSamochodu.PojemnoscId;
                samochod.CzyAktywny = true;

                db.Samochod.Add(samochod);
                db.SaveChanges();

                ViewBag.Success = "Dane zostały poprawie zapisane";
                return View();
            }

            ViewBag.Message = "Uzupełnij profil przed dodaniem samochodu";
            return RedirectToAction("DaneUzytkownika");
        }

        public ActionResult ListaSamochodow()
        {
            //string userLogin = User.Identity.GetUserId();

            //var uzytkownik = db.Klient.FirstOrDefault(u => u.LoginId.Equals(userLogin));

            var uzytkownik = PobierzUzytkownika(PobierzLoginUzytkownika());

            if (uzytkownik != null)
            {
                var listaSamochodow = db.Samochod.Where(s => s.KlientId.Equals(uzytkownik.KlientId) && s.CzyAktywny == true).ToList();

                if (listaSamochodow.Any())
                    return View(listaSamochodow);
            }
           
            ViewBag.Error = "Nie zdefiniowałeś jeszcze listy samochodów";
            return  View("Error");
        }

        public ActionResult EdytujSamochod(int? id)
        {
            if (id != null)
            {
                var samochod = db.Samochod.Single(m => m.SamochodId == id);

                if (samochod != null)
                {
                    ViewBag.MarkaId = new SelectList(db.Marka, "MarkaId", "Nazwa", samochod.MarkaId);
                    ViewBag.ModelId = new SelectList(db.Model, "ModelId", "Nazwa", samochod.ModelId);
                    ViewBag.PojemnoscId = new SelectList(db.Pojemnosc, "PojemnoscId", "Nazwa", samochod.PojemnoscId);
                    ViewBag.RodzajNadwoziaId = new SelectList(db.RodzajNadwozia, "RodzajNadwoziaId", "Nazwa", samochod.RodzajNadwoziaId);
                    ViewBag.RodzajPaliwaId = new SelectList(db.RodzajPaliwa, "RodzajPaliwaId", "Nazwa", samochod.RodzajPaliwaId);
                    ViewBag.RokProdukcjiId = new SelectList(db.RokProdukcji, "RokProdukcjiId", "Nazwa", samochod.RokProdukcjiId);

                    return View(samochod);
                }
            }
            
            return RedirectToAction("ListaSamochodow");
        }

        [HttpPost]
        public ActionResult EdytujSamochod(Samochod samochod)
        {
            samochod.CzyAktywny = true;
            db.Entry(samochod).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ListaSamochodow");
        }

        public ActionResult UsunSamochod(int? id)
        {
            if (id != null)
            {
                var samochod = db.Samochod.Single(m => m.SamochodId == id);
                samochod.CzyAktywny = false;
                db.Entry(samochod).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ListaSamochodow");
        }

        public ActionResult ZapytanieONapraweSamochodu()
        {
            //string userLogin = User.Identity.GetUserId();

            //var uzytkownik = db.Klient.FirstOrDefault(u => u.LoginId.Equals(userLogin));

            var uzytkownik = PobierzUzytkownika(PobierzLoginUzytkownika());

            if (uzytkownik != null)
            {
                var listaSamochodow = db.Samochod.Where(s => s.KlientId.Equals(uzytkownik.KlientId) && s.CzyAktywny == true).ToList();
                return View(listaSamochodow);    
            }

            ViewBag.Error = "Nie zdefiniowałeś jeszcze listy samochodów";
            return View("Error");
        }

        [HttpPost]
        public ActionResult ZapytanieONapraweSamochodu(FormCollection formCollection)
        {

            if (formCollection["WybranySamochod"] != null)
            {
                //string userLogin = User.Identity.GetUserId();

                //var uzytkownik = db.Klient.FirstOrDefault(u => u.LoginId.Equals(userLogin));

                var uzytkownik = PobierzUzytkownika(PobierzLoginUzytkownika());

                var listaSamochodow = db.Samochod.Where(s => s.KlientId.Equals(uzytkownik.KlientId) && s.CzyAktywny == true).ToList();

                var wybranySamochod = listaSamochodow.Single(s => s.SamochodId == Convert.ToInt32(formCollection["WybranySamochod"]));

                var nowaNaprawa = new Models.Naprawa();
                nowaNaprawa.KlientId = wybranySamochod.KlientId;
                nowaNaprawa.SamochodId = wybranySamochod.SamochodId;
                nowaNaprawa.PracownikId = 1;
                nowaNaprawa.OpisUsterki = formCollection["OpisUsterki"];
                nowaNaprawa.CzyNaprawiac = false;
                nowaNaprawa.CzyAktywny = true;

                db.Naprawa.Add(nowaNaprawa);
                db.SaveChanges();
                ViewBag.Success = "Wiadomość została wysłana";
            }

            return RedirectToAction("ZapytanieONapraweSamochodu");
        }

        public ActionResult ListaNapraw()
        {
            //string userLogin = User.Identity.GetUserId();

            //var uzytkownik = db.Klient.FirstOrDefault(u => u.LoginId.Equals(userLogin));

            var uzytkownik = PobierzUzytkownika(PobierzLoginUzytkownika());
            
            if (uzytkownik != null)
            {
                var listaNapraw = db.Naprawa.Where(n => n.KlientId == uzytkownik.KlientId).ToList();

                if (listaNapraw.Any())
                {
                    var szczegolowaListaNaprawKlienta = new List<DaneNaprawy>();

                    foreach (var item in listaNapraw)
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
                                CzyNaprawiono = item.CzyNaprawiony
                            }
                        );
                    }
                    return View(szczegolowaListaNaprawKlienta);
                }
            }

            ViewBag.Error = "Nie zdefiniowałeś jeszcze listy samochodów";
            return View("Error");
        }

        [HttpPost]
        public ActionResult ListaNapraw(DaneNaprawy daneNaprawy)
        {
            var naprawaKlienta = db.Naprawa.Single(n => n.NaprawaId == daneNaprawy.DaneNaprawyId);

            naprawaKlienta.CzyNaprawiac = daneNaprawy.CzyNaprawiac;
            db.Entry(naprawaKlienta).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("ListaNapraw");
        }

        /// <summary>
        /// Funkcja pobiera wszystkie dane o uzytkowniku z tabeli Klient
        /// </summary>
        /// <param name="login">Wymaga podania loginu</param>
        /// <returns>Zwraca dane uzytkonika</returns>
        private Klient PobierzUzytkownika(string login)
        {
            Klient uzytkownik = db.Klient.FirstOrDefault(u => u.LoginId.Equals(login));

            return uzytkownik;
        }
        /// <summary>
        /// Funkcja zwraca ID uzytkownika zalogowanego
        /// </summary>
        /// <returns>Zwraca id zalogowanego uzytkownika</returns>
        private string PobierzLoginUzytkownika()
        {
            string userLogin = User.Identity.GetUserId();

            return userLogin;
        }

    }
}