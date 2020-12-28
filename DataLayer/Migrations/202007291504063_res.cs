namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class res : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FlightReserves", "UserID", "dbo.Users");
            DropForeignKey("dbo.Reserves", "UserID", "dbo.Users");
            DropIndex("dbo.Reserves", new[] { "UserID" });
            DropIndex("dbo.FlightReserves", new[] { "UserID" });
            AlterColumn("dbo.Reserves", "UserID", c => c.String(nullable: false));
            AlterColumn("dbo.FlightReserves", "UserID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FlightReserves", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Reserves", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.FlightReserves", "UserID");
            CreateIndex("dbo.Reserves", "UserID");
            AddForeignKey("dbo.Reserves", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.FlightReserves", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
