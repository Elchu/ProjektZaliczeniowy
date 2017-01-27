using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedRacing.Models
{
    public class Pracownik
    {
        [Key]
        public int PracownikId { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Wprowadź nazwę modelu")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwę modelu")]
        public string Nazwisko { get; set; }
        
        [Display(Name = "Specjalność")]
        [Required(ErrorMessage = "Wprowadź nazwę modelu")]
        public string Specjalnosc { get; set; }

        [Display(Name = "Czy aktywny")]
        public bool CzyAktywny { get; set; }

        public virtual ICollection<Naprawa> Naprawa { get; set; }
    }
}