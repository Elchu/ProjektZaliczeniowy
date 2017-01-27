namespace SpeedRacing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAdnotationWhitPost : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Tresc", c => c.String());
            AlterColumn("dbo.Posts", "DataModyfikacji", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "DataModyfikacji", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "Tresc", c => c.String(nullable: false));
        }
    }
}
