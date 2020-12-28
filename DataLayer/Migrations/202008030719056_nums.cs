namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nums : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Residences", "Passengers", c => c.Int());
            AddColumn("dbo.Residences", "RoomNumber", c => c.Int());
            AddColumn("dbo.Flights", "Passengers", c => c.Int());
            DropColumn("dbo.Flights", "SeatNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "SeatNo", c => c.String(nullable: false));
            DropColumn("dbo.Flights", "Passengers");
            DropColumn("dbo.Residences", "RoomNumber");
            DropColumn("dbo.Residences", "Passengers");
        }
    }
}
