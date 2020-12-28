namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reserves", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.FlightReserves", "User_UserID", "dbo.Users");
            DropIndex("dbo.Reserves", new[] { "User_UserID" });
            DropIndex("dbo.FlightReserves", new[] { "User_UserID" });
            RenameColumn(table: "dbo.Reserves", name: "User_UserID", newName: "UserID");
            RenameColumn(table: "dbo.FlightReserves", name: "User_UserID", newName: "UserID");
            AlterColumn("dbo.Reserves", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.FlightReserves", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Reserves", "UserID");
            CreateIndex("dbo.FlightReserves", "UserID");
            AddForeignKey("dbo.Reserves", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.FlightReserves", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            DropColumn("dbo.Users", "HotelReserveID");
            DropColumn("dbo.Users", "FlightReserveID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "FlightReserveID", c => c.Int());
            AddColumn("dbo.Users", "HotelReserveID", c => c.Int());
            DropForeignKey("dbo.FlightReserves", "UserID", "dbo.Users");
            DropForeignKey("dbo.Reserves", "UserID", "dbo.Users");
            DropIndex("dbo.FlightReserves", new[] { "UserID" });
            DropIndex("dbo.Reserves", new[] { "UserID" });
            AlterColumn("dbo.FlightReserves", "UserID", c => c.Int());
            AlterColumn("dbo.Reserves", "UserID", c => c.Int());
            RenameColumn(table: "dbo.FlightReserves", name: "UserID", newName: "User_UserID");
            RenameColumn(table: "dbo.Reserves", name: "UserID", newName: "User_UserID");
            CreateIndex("dbo.FlightReserves", "User_UserID");
            CreateIndex("dbo.Reserves", "User_UserID");
            AddForeignKey("dbo.FlightReserves", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Reserves", "User_UserID", "dbo.Users", "UserID");
        }
    }
}
