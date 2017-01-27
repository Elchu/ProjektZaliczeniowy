using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedRacing.Models
{
    public class Samochod
    {
        [Key]
        public int SamochodId { get; set; }
        [Display(Name = "Wybierz klienta")]
        public int KlientId { get; set; }
        [Display(Name = "Numer rejestracyjny")]
        public string NrRejestracyjny { get; set; }
        [Display(Name = "Wybierz markę")]
        public int MarkaId { get; set; }
        [Display(Name = "Wybierz model")]
        public int ModelId { get; set; }
        [Display(Name = "Wybierz rodzaj nadwozia")]
        public int RodzajNadwoziaId { get; set; }
        [Display(Name = "Wybierz rodzaj paliwa")]
        public int RodzajPaliwaId { get; set; }
        [Display(Name = "Wybierz rok produkcji")]
        public int RokProdukcjiId { get; set; }
        [Display(Name = "Wybierz pojemność")]
        public int PojemnoscId { get; set; }
        [Display(Name = "Czy aktywny")]
        public bool CzyAktywny { get; set; }

        public virtual Marka Marka { get; set; }
        public virtual Model Model { get; set; }
        public virtual RodzajNadwozia RodzajNadwozia { get; set; }
        public virtual RodzajPaliwa RodzajPaliwa { get; set; }
        public virtual RokProdukcji RokProdukcji { get; set; }
        public virtual Pojemnosc Pojemnosc { get; set; }

        public virtual ICollection<Naprawa> Naprawa { get; set; }
    }
}