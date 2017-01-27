namespace SpeedRacing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllTableNaprawa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Klients",
                c => new
                    {
                        KlientId = c.Int(nullable: false, identity: true),
                        LoginId = c.Int(nullable: false),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Email = c.String(),
                        Telefon = c.String(),
                        Miasto = c.String(),
                        Ulica = c.String(),
                        NumerMieszkania = c.String(),
                        NrDomu = c.String(),
                        Kod = c.String(),
                        Opis = c.String(),
                        CzyAktywny = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KlientId);
            
            CreateTable(
                "dbo.Naprawas",
                c => new
                    {
                        NaprawaId = c.Int(nullable: false, identity: true),
                        KlientId = c.Int(nullable: false),
                        SamochodId = c.Int(nullable: false),
                        PracownikId = c.Int(nullable: false),
                        DataRozpoczecia = c.DateTime(),
                        DataZakonczenia = c.DateTime(),
                        OpisUsterki = c.String(),
                        OpisNaprawy = c.String(),
                        Cena = c.Decimal(precision: 18, scale: 2),
                        CzyNaprawiac = c.Boolean(nullable: false),
                        CzyAktywny = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NaprawaId)
                .ForeignKey("dbo.Klients", t => t.KlientId, cascadeDelete: true)
                .ForeignKey("dbo.Pracowniks", t => t.PracownikId, cascadeDelete: true)
                .ForeignKey("dbo.Samochods", t => t.SamochodId, cascadeDelete: true)
                .Index(t => t.KlientId)
                .Index(t => t.SamochodId)
                .Index(t => t.PracownikId);
            
            CreateTable(
                "dbo.Pracowniks",
                c => new
                    {
                        PracownikId = c.Int(nullable: false, identity: true),
                        Imie = c.String(nullable: false),
                        Nazwisko = c.String(nullable: false),
                        Specjalnosc = c.String(nullable: false),
                        CzyAktywny = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PracownikId);
            
            CreateTable(
                "dbo.Samochods",
                c => new
                    {
                        SamochodId = c.Int(nullable: false, identity: true),
                        KlientId = c.Int(nullable: false),
                        NrRejestracyjny = c.String(),
                        MarkaId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        RodzajNadwoziaId = c.Int(nullable: false),
                        RodzajPaliwaId = c.Int(nullable: false),
                        RokProdukcjiId = c.Int(nullable: false),
                        PojemnoscId = c.Int(nullable: false),
                        CzyAktywny = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SamochodId)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.Markas", t => t.MarkaId, cascadeDelete: true)
                .ForeignKey("dbo.Pojemnoscs", t => t.PojemnoscId, cascadeDelete: true)
                .ForeignKey("dbo.RodzajNadwozias", t => t.RodzajNadwoziaId, cascadeDelete: true)
                .ForeignKey("dbo.RodzajPaliwas", t => t.RodzajPaliwaId, cascadeDelete: true)
                .ForeignKey("dbo.RokProdukcjis", t => t.RokProdukcjiId, cascadeDelete: true)
                .Index(t => t.MarkaId)
                .Index(t => t.ModelId)
                .Index(t => t.RodzajNadwoziaId)
                .Index(t => t.RodzajPaliwaId)
                .Index(t => t.RokProdukcjiId)
                .Index(t => t.PojemnoscId);
            
            CreateTable(
                "dbo.Markas",
                c => new
                    {
                        MarkaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        CzyAktywny = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MarkaId);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        CzyAktywny = c.Boolean(nullable: false),
                        MarkaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.Markas", t => t.MarkaId)
                .Index(t => t.MarkaId);
            
            CreateTable(
                "dbo.Pojemnoscs",
                c => new
                    {
                        PojemnoscId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        CzyAktywny = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PojemnoscId);
            
            CreateTable(
                "dbo.RodzajNadwozias",
                c => new
                    {
                        RodzajNadwoziaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        CzyAktywny = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RodzajNadwoziaId);
            
            CreateTable(
                "dbo.RodzajPaliwas",
                c => new
                    {
                        RodzajPaliwaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        CzyAktywny = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RodzajPaliwaId);
            
            CreateTable(
                "dbo.RokProdukcjis",
                c => new
                    {
                        RokProdukcjiId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        CzyAktywny = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RokProdukcjiId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Samochods", "RokProdukcjiId", "dbo.RokProdukcjis");
            DropForeignKey("dbo.Samochods", "RodzajPaliwaId", "dbo.RodzajPaliwas");
            DropForeignKey("dbo.Samochods", "RodzajNadwoziaId", "dbo.RodzajNadwozias");
            DropForeignKey("dbo.Samochods", "PojemnoscId", "dbo.Pojemnoscs");
            DropForeignKey("dbo.Naprawas", "SamochodId", "dbo.Samochods");
            DropForeignKey("dbo.Samochods", "MarkaId", "dbo.Markas");
            DropForeignKey("dbo.Samochods", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "MarkaId", "dbo.Markas");
            DropForeignKey("dbo.Naprawas", "PracownikId", "dbo.Pracowniks");
            DropForeignKey("dbo.Naprawas", "KlientId", "dbo.Klients");
            DropIndex("dbo.Models", new[] { "MarkaId" });
            DropIndex("dbo.Samochods", new[] { "PojemnoscId" });
            DropIndex("dbo.Samochods", new[] { "RokProdukcjiId" });
            DropIndex("dbo.Samochods", new[] { "RodzajPaliwaId" });
            DropIndex("dbo.Samochods", new[] { "RodzajNadwoziaId" });
            DropIndex("dbo.Samochods", new[] { "ModelId" });
            DropIndex("dbo.Samochods", new[] { "MarkaId" });
            DropIndex("dbo.Naprawas", new[] { "PracownikId" });
            DropIndex("dbo.Naprawas", new[] { "SamochodId" });
            DropIndex("dbo.Naprawas", new[] { "KlientId" });
            DropTable("dbo.RokProdukcjis");
            DropTable("dbo.RodzajPaliwas");
            DropTable("dbo.RodzajNadwozias");
            DropTable("dbo.Pojemnoscs");
            DropTable("dbo.Models");
            DropTable("dbo.Markas");
            DropTable("dbo.Samochods");
            DropTable("dbo.Pracowniks");
            DropTable("dbo.Naprawas");
            DropTable("dbo.Klients");
        }
    }
}
