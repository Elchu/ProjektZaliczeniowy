using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedRacing.Models.Blog
{
    public class Post
    {
        [Key]
        public int PostyId { get; set; }

        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Pole tytuł jest wymagane")]
        public string Tytul { get; set; }

        [Display(Name = "Krótki opis")]
        [DataType(DataType.MultilineText)]
        public string KrotkiOpis { get; set; }

        
        [Display(Name = "Treść")]
        public string Tresc { get; set; }

        public string Opis { get; set; }

        [Display(Name = "Przyjazny opis")]
        public string PrzyjazdyOpis { get; set; }

        [Display(Name = "Data publikacji")]
        public DateTime DataPublikacji { get; set; }

        public string Autor { get; set; }

        [Display(Name = "Data modyfikacji")]
        public DateTime? DataModyfikacji { get; set; }

        [Display(Name = "Czy opublikowany")]
        public bool CzyOpublikowany { get; set; }

        [Display(Name = "Zdjęcie")]
        public string Zdjecie { get; set; }

        public int KategorieId { get; set; }
        public virtual Kategorie Kategorie { get; set; }

        public virtual ICollection<Komentarze> Komentarze { get; set; }
    }
}