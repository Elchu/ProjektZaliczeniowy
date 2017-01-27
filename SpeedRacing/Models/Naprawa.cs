using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedRacing.Models
{
    public class Naprawa
    {
        [Key]
        public int NaprawaId { get; set; }
        [Display(Name = "Wybierz klienta")]
        public int KlientId { get; set; }
        [Display(Name = "Wybierz samochód")]
        public int SamochodId { get; set; }
        [Display(Name = "Wybierz pracownika")]
        public int PracownikId { get; set; }
        [Display(Name = "Data rozpoczęcia")]
        public DateTime? DataRozpoczecia { get; set; }
        [Display(Name = "Data zakończenia")]
        public DateTime? DataZakonczenia { get; set; }
        [Display(Name = "Opis usterki")]
        [DataType(DataType.MultilineText)]
        public string OpisUsterki { get; set; }
        [Display(Name = "Opis naprawy")]
        [DataType(DataType.MultilineText)]
        public string OpisNaprawy { get; set; }
        public decimal? Cena { get; set; }
        [Display(Name = "Czy naprawiać")]
        public bool CzyNaprawiac { get; set; }
        [Display(Name = "Czy naprawiony")]
        public bool CzyNaprawiony { get; set; }
        [Display(Name = "Czy aktywny")]
        public bool CzyAktywny { get; set; }

        public virtual Klient Klient { get; set; }
        public virtual Samochod Samochod { get; set; }
        public virtual Pracownik Pracownik { get; set; }

    }
}