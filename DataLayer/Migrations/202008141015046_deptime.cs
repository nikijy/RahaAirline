namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deptime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "DepartureTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "DepartureTime");
        }
    }
}
