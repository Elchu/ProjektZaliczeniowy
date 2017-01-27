using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedRacing.Models.Blog
{
    public class Kategorie
    {
        [Key]
        public int KategorieId { get; set; }

        [Required(ErrorMessage = "Pole Nazwa jest wymagane")]
        public string Nazwa { get; set; }

        [Display(Name = "Przyjazna nazwa")]
        public string PrzyjaznaNazwa { get; set; }

        public string Opis { get; set; }

        [Display(Name = "Data utworzenia")]
        public DateTime DataUtworzenia { get; set; }

        [Display(Name = "Czy opublikowany")]
        public bool CzyOpublikowany { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}