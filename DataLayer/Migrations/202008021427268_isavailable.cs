namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isavailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Residences", "IsAvailable", c => c.Boolean());
            AddColumn("dbo.Flights", "IsAvailable", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "IsAvailable");
            DropColumn("dbo.Residences", "IsAvailable");
        }
    }
}
