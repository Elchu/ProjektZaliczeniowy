using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedRacing.Models.Blog
{
    public class Komentarze
    {
        [Key]
        public int KomentarzeId { get; set; }

        [Required(ErrorMessage = "Pole treść jest wymagana")]
        public string Tresc { get; set; }

        [Display(Name = "Data publikacji")]
        public DateTime DataPublikacji { get; set; }

        public string Ip { get; set; }

        [Display(Name = "Użytkownik")]
        public string Uzytkownik { get; set; }

        public string Nick { get; set; }

        [Display(Name = "Czy opublikowane")]
        public bool CzyOpublikowany { get; set; }

        public int PostyId { get; set; }
        public virtual Post Post { get; set; }
    }
}