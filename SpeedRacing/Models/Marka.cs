using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedRacing.Models
{
    public class Marka
    {
        [Key]
        public int MarkaId { get; set; }
        [Required(ErrorMessage="Wprowadź nazwę marki")]
        public string Nazwa { get; set; }
        [Display(Name = "Czy aktywny")]
        public bool CzyAktywny { get; set; }

        public virtual ICollection<Model> Model { get; set; }
        public virtual ICollection<Samochod> Samochod { get; set; }
    }
}