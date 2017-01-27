using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpeedRacing.Models;

namespace SpeedRacing.BussinesLogic
{
    public static class BStatystyki
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static int IloscUzytkownikow()
        {
            return db.Users.Count();
        }

        public static int IloscSamochodowNaSprzedaz()
        {
            return db.KomisPojazd.Count(k => k.CzyNaSprzedaz);
        }

        public static int IloscSamochodowPoszukiwanych()
        {
            return db.KomisPojazd.Count(k => k.CzyPoszukiwany);
        }

        public static int IloscSamochodSprzedanych()
        {
            return db.KomisPojazd.Count(k => k.CzySprzedany);
        }

        public static int IloscWszystkichPostow()
        {
            return db.Posts.Count();
        }

        public static int IloscWszystkichKomentarzy()
        {
            return db.Komentarzes.Count();
        }
    }
}