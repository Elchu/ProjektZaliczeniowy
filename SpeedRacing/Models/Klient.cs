using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedRacing.Models
{
    public class Klient
    {
        [Key]
        public int KlientId { get; set; }
        public string LoginId { get; set; }
        [Display(Name = "Imię")]
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        [EmailAddress (ErrorMessage="Wprowadź poprawny adres email")]
        public string Email { get; set; }
        [Phone (ErrorMessage="Wprowadź poprawny numer telefonu")]
        public string Telefon { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        [Display(Name = "Numer mieszkania")]
        public string NumerMieszkania { get; set; }
        [Display(Name = "Nr domu")]
        public string NrDomu { get; set; }
        public string Kod { get; set; }
        public string Opis { get; set; }
        [Display(Name = "Czy aktywny")]
        public bool CzyAktywny { get; set; }

        public virtual ICollection<Naprawa> Naprawa { get; set; }
    }
}