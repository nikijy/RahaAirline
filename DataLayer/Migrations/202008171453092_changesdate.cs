namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reserves", "CheckInDate", c => c.String());
            AddColumn("dbo.Reserves", "CheckOutDate", c => c.Int(nullable: false));
            DropColumn("dbo.Flights", "IsAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "IsAvailable", c => c.Boolean());
            DropColumn("dbo.Reserves", "CheckOutDate");
            DropColumn("dbo.Reserves", "CheckInDate");
        }
    }
}
