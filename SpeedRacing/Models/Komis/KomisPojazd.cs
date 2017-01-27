using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedRacing.Models.Komis
{
    public class KomisPojazd
    {
        [Key]
        [Display(Name = "Id pojazdu:")]
        public int KomisPojazdId { get; set; }
        
        [Required(ErrorMessage = "Wprowadź nazwę marki:")]
        public string Marka { get; set; }
        
        [Required(ErrorMessage = "Wprowadź nazwę kategorii:")]
        public string Model { get; set; }
        
        [Required(ErrorMessage = "Wprowadź rok:")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Rok { get; set; }
        
        [Required(ErrorMessage = "Wprowadź kilometry:")]
        public double Kilometry { get; set; }
        
        [Required(ErrorMessage = "Wprowadź typ nadwozia:")]
        [Display(Name = "Typ nadwozia:")]
        public string TypNadwozia { get; set; }
        
        [Required(ErrorMessage = "Wprowadź nazwę skrzyni biegów:")]
        [Display(Name = "Skrzynia biegów:")]
        public string SkrzyniaBiegow { get; set; }
        
        [Required(ErrorMessage = "Wprowadź cenę proponowaną:")]
        [Display(Name = "Cena proponowana:")]
        public decimal CenaProponowana { get; set; }
        
        public double? Rabat { get; set; }
        
        [Required(ErrorMessage = "Wprowadź cenę sprzedaży:")]
        [Display(Name = "Cena sprzedaży:")]
        public decimal CenaSprzedazy { get; set; }
        
        [Required(ErrorMessage = "Wprowadź datę dodania:")]
        [Display(Name = "Data dodania:")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataDodania { get; set; }
        
        [Display(Name = "Data modyfikacji:")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataModyfikacji { get; set; }
        
        [Display(Name = "Właściciel:")]
        public string UserId { get; set; }
        
        [Required(ErrorMessage = "Wprowadź pełny adres:")]
        public string Adres { get; set; }
        
        [Required(ErrorMessage = "Wprowadź krótki opis samochodu:")]
        [Display(Name = "Krótki opis:")]
        [DataType(DataType.MultilineText)]
        public string KrotkiOpis { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string Uwagi { get; set; }
        
        [Required(ErrorMessage = "Wprowadź opis samochodu:")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Treść:")]
        public string Tresc { get; set; }
        
        [Display(Name = "Sprzedany:")]
        public bool CzySprzedany { get; set; }
        
        [Display(Name = "Poszukiwany:")]
        public bool CzyPoszukiwany { get; set; }
        
        [Display(Name = "Zarezerwowany:")]
        public bool CzyZarezerwowany { get; set; }
        
        [Display(Name = "Na sprzedaż:")]
        public bool CzyNaSprzedaz { get; set; }
        
        [Display(Name = "Wycofany:")]
        public bool CzyWycofany { get; set; }
        
        [Display(Name = "Aktywny:")]
        public bool CzyAktywny { get; set; }
        
        [Display(Name = "Wyróżniony:")]
        public bool Wyrozniony { get; set; }
        
        public bool Promocja { get; set; }
        [Display(Name = "Wyprzedaż:")]
        
        public bool Wyprzedaz { get; set; }
        [Display(Name = "Zdjęcie 1:")]
        
        public string Zdjecie1 { get; set; }
        [Display(Name = "Zdjęcie 2:")]
        
        public string Zdjecie2 { get; set; }
        [Display(Name = "Zdjęcie 3:")]
        
        public string Zdjecie3 { get; set; }

        [Display(Name = "zdjęcie 4:")]
        public string Zdjecie4 { get; set; }

        public int KomisKategoriaId { get; set; }
        public virtual KomisKategoria KomisKategoria { get; set; }
        
    }
}