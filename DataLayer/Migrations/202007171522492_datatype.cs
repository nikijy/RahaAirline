namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Flights", "Departure", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Flights", "Departure", c => c.String(nullable: false));
        }
    }
}
