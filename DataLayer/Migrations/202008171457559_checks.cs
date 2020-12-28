namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reserves", "CheckIn", c => c.String());
            AddColumn("dbo.Reserves", "CheckOut", c => c.String());
            DropColumn("dbo.Reserves", "CheckInDate");
            DropColumn("dbo.Reserves", "CheckOutDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reserves", "CheckOutDate", c => c.Int(nullable: false));
            AddColumn("dbo.Reserves", "CheckInDate", c => c.String());
            DropColumn("dbo.Reserves", "CheckOut");
            DropColumn("dbo.Reserves", "CheckIn");
        }
    }
}
