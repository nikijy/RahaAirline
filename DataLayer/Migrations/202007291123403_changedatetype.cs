namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatetype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Residences", "CheckIn", c => c.String());
            AlterColumn("dbo.Residences", "CheckOut", c => c.String());
            AlterColumn("dbo.Reserves", "DateTime", c => c.String());
            AlterColumn("dbo.FlightReserves", "DateTime", c => c.String());
            AlterColumn("dbo.Flights", "Departure", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Flights", "Departure", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FlightReserves", "DateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reserves", "DateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Residences", "CheckOut", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Residences", "CheckIn", c => c.DateTime(nullable: false));
        }
    }
}
