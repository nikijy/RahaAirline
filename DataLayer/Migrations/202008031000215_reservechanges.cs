namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservechanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reserves", "Passengers", c => c.Int(nullable: false));
            AddColumn("dbo.Reserves", "RoomNumber", c => c.Int(nullable: false));
            AddColumn("dbo.FlightReserves", "Passengers", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FlightReserves", "Passengers");
            DropColumn("dbo.Reserves", "RoomNumber");
            DropColumn("dbo.Reserves", "Passengers");
        }
    }
}
