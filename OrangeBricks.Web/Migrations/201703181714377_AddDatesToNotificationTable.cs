namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatesToNotificationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NotificationObjects", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.NotificationObjects", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NotificationObjects", "UpdatedAt");
            DropColumn("dbo.NotificationObjects", "CreatedAt");
        }
    }
}
