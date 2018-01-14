namespace MaerskLineWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShipMigrationContainerToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ships", "ContainerNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ships", "ContainerNo", c => c.String());
        }
    }
}
