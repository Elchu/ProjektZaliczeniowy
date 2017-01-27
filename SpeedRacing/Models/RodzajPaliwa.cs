﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedRacing.Models
{
    public class RodzajPaliwa
    {
        [Key]
        public int RodzajPaliwaId { get; set; }
        [Required(ErrorMessage = "Wprowadź nazwę dla rodzaju nadwozia")]
        public string Nazwa { get; set; }
        [Display(Name = "Czy aktywny")]
        public bool CzyAktywny { get; set; }

        public virtual ICollection<Samochod> Samochod { get; set; }
    }
}