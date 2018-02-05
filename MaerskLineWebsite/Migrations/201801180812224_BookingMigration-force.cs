namespace MaerskLineWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingMigrationforce : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "AgentBooked", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "AgentBooked");
        }
    }
}
