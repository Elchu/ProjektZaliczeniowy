namespace SpeedRacing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodaniePolaCzyNaprawionoDoNaprawy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Naprawas", "CzyNaprawiony", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Naprawas", "CzyNaprawiony");
        }
    }
}
