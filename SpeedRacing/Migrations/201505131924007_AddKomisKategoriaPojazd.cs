namespace SpeedRacing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKomisKategoriaPojazd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KomisKategorias",
                c => new
                    {
                        KomisKategoriaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Opis = c.String(),
                        CzyAktywny = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KomisKategoriaId);
            
            CreateTable(
                "dbo.KomisPojazds",
                c => new
                    {
                        KomisPojazdId = c.Int(nullable: false, identity: true),
                        Marka = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Rok = c.DateTime(nullable: false),
                        Kilometry = c.Double(nullable: false),
                        TypNadwozia = c.String(nullable: false),
                        SkrzyniaBiegow = c.String(nullable: false),
                        CenaProponowana = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rabat = c.Double(),
                        CenaSprzedazy = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataDodania = c.DateTime(nullable: false),
                        DataModyfikacji = c.DateTime(nullable: false),
                        UserId = c.String(),
                        Adres = c.String(nullable: false),
                        KrotkiOpis = c.String(nullable: false),
                        Uwagi = c.String(),
                        Tresc = c.String(nullable: false),
                        CzySprzedany = c.Boolean(nullable: false),
                        CzyPoszukiwany = c.Boolean(nullable: false),
                        CzyZarezerwowany = c.Boolean(nullable: false),
                        CzyNaSprzedaz = c.Boolean(nullable: false),
                        CzyWycofany = c.Boolean(nullable: false),
                        CzyAktywny = c.Boolean(nullable: false),
                        Wyrozniony = c.Boolean(nullable: false),
                        Promocja = c.Boolean(nullable: false),
                        Wyprzedaz = c.Boolean(nullable: false),
                        Zdjecie1 = c.String(),
                        Zdjecie2 = c.String(),
                        Zdjecie3 = c.String(),
                        Zdjecie4 = c.String(),
                        KomisKategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KomisPojazdId)
                .ForeignKey("dbo.KomisKategorias", t => t.KomisKategoriaId, cascadeDelete: true)
                .Index(t => t.KomisKategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KomisPojazds", "KomisKategoriaId", "dbo.KomisKategorias");
            DropIndex("dbo.KomisPojazds", new[] { "KomisKategoriaId" });
            DropTable("dbo.KomisPojazds");
            DropTable("dbo.KomisKategorias");
        }
    }
}
