using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SpeedRacing.Models
{
    // Dane profilu dla użytkownika można dodać, dodając więcej właściwości do własnej klasy ApplicationUser. Więcej informacji można znaleźć na stronie http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Element authenticationType musi pasować do elementu zdefiniowanego w elemencie CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Dodaj tutaj niestandardowe oświadczenia użytkownika
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SpeedRacing.Models.Blog.Kategorie> Kategories { get; set; }

        public System.Data.Entity.DbSet<SpeedRacing.Models.Blog.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<SpeedRacing.Models.Blog.Komentarze> Komentarzes { get; set; }

        public System.Data.Entity.DbSet<Klient> Klient { get; set; }

        public System.Data.Entity.DbSet<Marka> Marka { get; set; }

        public System.Data.Entity.DbSet<Model> Model { get; set; }

        public System.Data.Entity.DbSet<Pojemnosc> Pojemnosc { get; set; }

        public System.Data.Entity.DbSet<Pracownik> Pracownik { get; set; }

        public System.Data.Entity.DbSet<RodzajNadwozia> RodzajNadwozia { get; set; }

        public System.Data.Entity.DbSet<RodzajPaliwa> RodzajPaliwa { get; set; }

        public System.Data.Entity.DbSet<RokProdukcji> RokProdukcji { get; set; }

        public System.Data.Entity.DbSet<Samochod> Samochod { get; set; }

        public System.Data.Entity.DbSet<Naprawa> Naprawa { get; set; }

        public System.Data.Entity.DbSet<Komis.KomisKategoria> KomisKategoria { get; set; }

        public System.Data.Entity.DbSet<Komis.KomisPojazd> KomisPojazd { get; set; }

        //public System.Data.Entity.DbSet<SpeedRacing.ViewModel.DaneNaprawy> DaneNaprawies { get; set; }
    }
}