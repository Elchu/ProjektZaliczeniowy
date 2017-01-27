using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedRacing.Models.Komis
{
    public class KomisKategoria
    {
        [Key]
        [Display(Name = "Id kategorii:")]
        public int KomisKategoriaId { get; set; }
        [Required(ErrorMessage = "Wprowadź nazwę kategorii:")]
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        //[Display(Name = "Czy aktywny:22u")]
        [Display(Name = "Czy aktywny:")]
        public bool CzyAktywny { get; set; }

        public virtual ICollection<KomisPojazd> KomisPojazd { get; set; }
    }
}