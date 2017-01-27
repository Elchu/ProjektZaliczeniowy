using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedRacing.ViewModel
{
    public class Statystyki
    {
        public int IloscUzytkownikowWSerwisie { get; set; }
        public int IloscSamochodowNaSprzedaz { get; set; }
        public int IloscSamochodowPoszukiwanych { get; set; }
        public int IloscSamochodowSprzedanych { get; set; }
        public int IloscPostow { get; set; }
        public int IloscKomentarzy { get; set; }
    }
}