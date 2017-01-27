namespace SpeedRacing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategories",
                c => new
                    {
                        KategorieId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        PrzyjaznaNazwa = c.String(),
                        Opis = c.String(),
                        DataUtworzenia = c.DateTime(nullable: false),
                        CzyOpublikowany = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KategorieId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostyId = c.Int(nullable: false, identity: true),
                        Tytul = c.String(nullable: false),
                        KrotkiOpis = c.String(),
                        Tresc = c.String(nullable: false),
                        Opis = c.String(),
                        PrzyjazdyOpis = c.String(),
                        DataPublikacji = c.DateTime(nullable: false),
                        Autor = c.String(),
                        DataModyfikacji = c.DateTime(nullable: false),
                        CzyOpublikowany = c.Boolean(nullable: false),
                        Zdjecie = c.String(),
                        KategorieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostyId)
                .ForeignKey("dbo.Kategories", t => t.KategorieId, cascadeDelete: true)
                .Index(t => t.KategorieId);
            
            CreateTable(
                "dbo.Komentarzes",
                c => new
                    {
                        KomentarzeId = c.Int(nullable: false, identity: true),
                        Tresc = c.String(nullable: false),
                        DataPublikacji = c.DateTime(nullable: false),
                        Ip = c.String(),
                        Uzytkownik = c.String(),
                        Nick = c.String(),
                        CzyOpublikowany = c.Boolean(nullable: false),
                        PostyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KomentarzeId)
                .ForeignKey("dbo.Posts", t => t.PostyId, cascadeDelete: true)
                .Index(t => t.PostyId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Komentarzes", "PostyId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "KategorieId", "dbo.Kategories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Komentarzes", new[] { "PostyId" });
            DropIndex("dbo.Posts", new[] { "KategorieId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Komentarzes");
            DropTable("dbo.Posts");
            DropTable("dbo.Kategories");
        }
    }
}
