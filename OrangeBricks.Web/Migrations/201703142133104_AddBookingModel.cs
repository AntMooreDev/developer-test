namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookingModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        BuyerUserId = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Property_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.Property_Id)
                .Index(t => t.Property_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Property_Id", "dbo.Properties");
            DropIndex("dbo.Bookings", new[] { "Property_Id" });
            DropTable("dbo.Bookings");
        }
    }
}
