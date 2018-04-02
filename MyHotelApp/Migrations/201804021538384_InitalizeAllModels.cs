namespace MyHotelApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalizeAllModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuestAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        StateId = c.Int(nullable: false),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                        IsMember = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuestReservationJunctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuestAccountId = c.Int(nullable: false),
                        ReservationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuestAccounts", t => t.GuestAccountId, cascadeDelete: true)
                .ForeignKey("dbo.Reservations", t => t.ReservationId, cascadeDelete: true)
                .Index(t => t.GuestAccountId)
                .Index(t => t.ReservationId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuestAccountId = c.Int(),
                        RoomId = c.Int(),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        CheckedIn = c.Boolean(nullable: false),
                        Balance = c.Double(nullable: false),
                        RoomTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuestAccounts", t => t.GuestAccountId)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.GuestAccountId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomTypeId = c.Int(nullable: false),
                        IsClean = c.Boolean(nullable: false),
                        RoomStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeId, cascadeDelete: true)
                .Index(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Byte(nullable: false),
                        Type = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoomAvailabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentAvailability = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GuestReservationJunctions", "ReservationId", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.Reservations", "GuestAccountId", "dbo.GuestAccounts");
            DropForeignKey("dbo.GuestReservationJunctions", "GuestAccountId", "dbo.GuestAccounts");
            DropForeignKey("dbo.GuestAccounts", "StateId", "dbo.States");
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            DropIndex("dbo.Reservations", new[] { "RoomId" });
            DropIndex("dbo.Reservations", new[] { "GuestAccountId" });
            DropIndex("dbo.GuestReservationJunctions", new[] { "ReservationId" });
            DropIndex("dbo.GuestReservationJunctions", new[] { "GuestAccountId" });
            DropIndex("dbo.GuestAccounts", new[] { "StateId" });
            DropTable("dbo.RoomAvailabilities");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.Reservations");
            DropTable("dbo.GuestReservationJunctions");
            DropTable("dbo.States");
            DropTable("dbo.GuestAccounts");
        }
    }
}
