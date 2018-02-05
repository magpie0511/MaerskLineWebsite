namespace MaerskLineWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Cid = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                        ShipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Customers", t => t.Cid, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.Ships", t => t.ShipId, cascadeDelete: true)
                .Index(t => t.Cid)
                .Index(t => t.ScheduleId)
                .Index(t => t.ShipId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CId = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 255),
                        LName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ContactNo = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.CId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        Destination = c.String(nullable: false, maxLength: 255),
                        Origin = c.String(),
                        DepartureDateTime = c.DateTime(nullable: false),
                        ArrivalDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleId);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        ContainerNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipId);
            
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerId = c.Int(nullable: false, identity: true),
                        ContainerWeight = c.Double(nullable: false),
                        ContainerType = c.String(),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerId)
                .ForeignKey("dbo.Bookings", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Containers", "BookId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "ShipId", "dbo.Ships");
            DropForeignKey("dbo.Bookings", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Bookings", "Cid", "dbo.Customers");
            DropIndex("dbo.Containers", new[] { "BookId" });
            DropIndex("dbo.Bookings", new[] { "ShipId" });
            DropIndex("dbo.Bookings", new[] { "ScheduleId" });
            DropIndex("dbo.Bookings", new[] { "Cid" });
            DropTable("dbo.Containers");
            DropTable("dbo.Ships");
            DropTable("dbo.Schedules");
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
        }
    }
}
