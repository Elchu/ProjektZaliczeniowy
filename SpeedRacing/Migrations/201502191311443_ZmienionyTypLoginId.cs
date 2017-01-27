namespace SpeedRacing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZmienionyTypLoginId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Klients", "LoginId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Klients", "LoginId", c => c.Int(nullable: false));
        }
    }
}
