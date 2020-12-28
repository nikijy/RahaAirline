namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        ShortDescription = c.String(nullable: false, maxLength: 300),
                        Text = c.String(nullable: false),
                        Visit = c.Int(nullable: false),
                        ShowInSlider = c.Boolean(nullable: false),
                        Image = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Tag = c.String(),
                    })
                .PrimaryKey(t => t.PageID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        PageID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 150),
                        CommentText = c.String(nullable: false, maxLength: 600),
                        CreateDate = c.DateTime(nullable: false),
                        Residence_ResidenceID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Pages", t => t.PageID, cascadeDelete: true)
                .ForeignKey("dbo.Residences", t => t.Residence_ResidenceID)
                .Index(t => t.PageID)
                .Index(t => t.Residence_ResidenceID);
            
            CreateTable(
                "dbo.Residences",
                c => new
                    {
                        ResidenceID = c.Int(nullable: false, identity: true),
                        ResidenceTypeID = c.Int(nullable: false),
                        Location = c.String(nullable: false, maxLength: 300),
                        Image = c.String(),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        Price = c.Int(nullable: false),
                        Visit = c.Int(nullable: false),
                        ShortDescription = c.String(nullable: false, maxLength: 300),
                        Text = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Tag = c.String(),
                    })
                .PrimaryKey(t => t.ResidenceID)
                .ForeignKey("dbo.ResidenceTypes", t => t.ResidenceTypeID, cascadeDelete: true)
                .Index(t => t.ResidenceTypeID);
            
            CreateTable(
                "dbo.Reserves",
                c => new
                    {
                        ReserveID = c.Int(nullable: false, identity: true),
                        ResidenceID = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        IsFinally = c.Boolean(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ReserveID)
                .ForeignKey("dbo.Residences", t => t.ResidenceID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.ResidenceID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 150),
                        HotelReserveID = c.Int(),
                        FlightReserveID = c.Int(),
                        FullName = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 100),
                        Mobile = c.String(nullable: false, maxLength: 11),
                        Password = c.String(nullable: false, maxLength: 20),
                        ConfirmPassword = c.String(nullable: false),
                        NationalCode = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.FlightReserves",
                c => new
                    {
                        ReserveID = c.Int(nullable: false, identity: true),
                        FlightID = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        IsFinally = c.Boolean(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ReserveID)
                .ForeignKey("dbo.Flights", t => t.FlightID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.FlightID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightID = c.Int(nullable: false, identity: true),
                        FlightClassID = c.Int(nullable: false),
                        From = c.String(nullable: false, maxLength: 50),
                        Destination = c.String(nullable: false, maxLength: 50),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        Departure = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        SeatNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FlightID)
                .ForeignKey("dbo.FlightClasses", t => t.FlightClassID, cascadeDelete: true)
                .Index(t => t.FlightClassID);
            
            CreateTable(
                "dbo.FlightClasses",
                c => new
                    {
                        FlightClassID = c.Int(nullable: false, identity: true),
                        FlightClassKind = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.FlightClassID);
            
            CreateTable(
                "dbo.ResidenceTypes",
                c => new
                    {
                        ResidenceTypeID = c.Int(nullable: false, identity: true),
                        ResidenceKind = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ResidenceTypeID);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceID = c.Int(nullable: false, identity: true),
                        Country = c.String(nullable: false, maxLength: 150),
                        City = c.String(nullable: false, maxLength: 150),
                        Image = c.String(),
                        Price = c.Int(nullable: false),
                        Visit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlaceID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ServiceText = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => t.ServiceID);
            
            CreateTable(
                "dbo.UserMessages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        Subject = c.String(maxLength: 80),
                        Text = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.MessageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Residences", "ResidenceTypeID", "dbo.ResidenceTypes");
            DropForeignKey("dbo.Reserves", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.FlightReserves", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.FlightReserves", "FlightID", "dbo.Flights");
            DropForeignKey("dbo.Flights", "FlightClassID", "dbo.FlightClasses");
            DropForeignKey("dbo.Reserves", "ResidenceID", "dbo.Residences");
            DropForeignKey("dbo.Comments", "Residence_ResidenceID", "dbo.Residences");
            DropForeignKey("dbo.Comments", "PageID", "dbo.Pages");
            DropForeignKey("dbo.Pages", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Flights", new[] { "FlightClassID" });
            DropIndex("dbo.FlightReserves", new[] { "User_UserID" });
            DropIndex("dbo.FlightReserves", new[] { "FlightID" });
            DropIndex("dbo.Reserves", new[] { "User_UserID" });
            DropIndex("dbo.Reserves", new[] { "ResidenceID" });
            DropIndex("dbo.Residences", new[] { "ResidenceTypeID" });
            DropIndex("dbo.Comments", new[] { "Residence_ResidenceID" });
            DropIndex("dbo.Comments", new[] { "PageID" });
            DropIndex("dbo.Pages", new[] { "CategoryID" });
            DropTable("dbo.UserMessages");
            DropTable("dbo.Services");
            DropTable("dbo.Places");
            DropTable("dbo.ResidenceTypes");
            DropTable("dbo.FlightClasses");
            DropTable("dbo.Flights");
            DropTable("dbo.FlightReserves");
            DropTable("dbo.Users");
            DropTable("dbo.Reserves");
            DropTable("dbo.Residences");
            DropTable("dbo.Comments");
            DropTable("dbo.Pages");
            DropTable("dbo.Categories");
        }
    }
}
