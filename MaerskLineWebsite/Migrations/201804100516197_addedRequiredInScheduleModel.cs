namespace MaerskLineWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRequiredInScheduleModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "Origin", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "Origin", c => c.String());
        }
    }
}
