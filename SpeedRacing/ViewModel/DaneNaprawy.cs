using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedRacing.ViewModel
{
    public class DaneNaprawy
    {
        public int DaneNaprawyId { get; set; }
        public string NazwiskoKlienta { get; set; }
        public string DaneSamochodu { get; set; }
        public string DanePracownika { get; set; }
        public DateTime? DataRozpoczecia { get; set; }
        public DateTime? DataZakonczenia { get; set; }
        public string OpisUsterki { get; set; }
        public string OpisNaprawy { get; set; }
        public decimal? Cena { get; set; }
        public bool CzyNaprawiac { get; set; }
        public bool CzyNaprawiono { get; set; }
        public bool CzyAktywny { get; set; }
    }
}