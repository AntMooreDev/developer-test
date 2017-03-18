namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotificationTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotificationChanges",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Verb = c.String(),
                        ActorUserId = c.String(),
                        NotificationObject_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NotificationObjects", t => t.NotificationObject_Id)
                .Index(t => t.NotificationObject_Id);
            
            CreateTable(
                "dbo.NotificationObjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Object = c.String(),
                        Notification_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Notifications", t => t.Notification_Id)
                .Index(t => t.Notification_Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotificationChanges", "NotificationObject_Id", "dbo.NotificationObjects");
            DropForeignKey("dbo.NotificationObjects", "Notification_Id", "dbo.Notifications");
            DropIndex("dbo.NotificationObjects", new[] { "Notification_Id" });
            DropIndex("dbo.NotificationChanges", new[] { "NotificationObject_Id" });
            DropTable("dbo.Notifications");
            DropTable("dbo.NotificationObjects");
            DropTable("dbo.NotificationChanges");
        }
    }
}
