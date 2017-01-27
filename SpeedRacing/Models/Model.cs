using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedRacing.Models
{
    public class Model
    {
        [Key]
        public int ModelId { get; set; }
        [Required(ErrorMessage = "Wprowadź nazwę modelu")]
        public string Nazwa { get; set; }
        [Display(Name = "Czy aktywny")]
        public bool CzyAktywny { get; set; }

        [Display(Name = "Wybierz markę")]
        public int MarkaId { get; set; }
        public virtual Marka Marka { get; set; }

        public virtual ICollection<Samochod> Samochod { get; set; }
    }
}