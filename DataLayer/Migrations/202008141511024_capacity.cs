namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capacity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "Capacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "Capacity");
        }
    }
}
