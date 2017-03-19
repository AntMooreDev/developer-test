namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNotificationDatePropertiesAndAddObjectId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NotificationObjects", "ObjectId", c => c.String());
            AddColumn("dbo.Notifications", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Notifications", "UpdatedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.NotificationObjects", "CreatedAt");
            DropColumn("dbo.NotificationObjects", "UpdatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NotificationObjects", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.NotificationObjects", "CreatedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.Notifications", "UpdatedAt");
            DropColumn("dbo.Notifications", "CreatedAt");
            DropColumn("dbo.NotificationObjects", "ObjectId");
        }
    }
}
