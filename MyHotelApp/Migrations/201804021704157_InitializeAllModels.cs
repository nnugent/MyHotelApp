namespace MyHotelApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeAllModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rooms", "RoomStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "RoomTypeId");
            CreateIndex("dbo.Rooms", "RoomStatusId");
            AddForeignKey("dbo.Rooms", "RoomStatusId", "dbo.RoomStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reservations", "RoomTypeId", "dbo.RoomTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Rooms", "RoomStatus");
            DropTable("dbo.RoomAvailabilities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoomAvailabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentAvailability = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rooms", "RoomStatus", c => c.String());
            DropForeignKey("dbo.Reservations", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.Rooms", "RoomStatusId", "dbo.RoomStatus");
            DropIndex("dbo.Rooms", new[] { "RoomStatusId" });
            DropIndex("dbo.Reservations", new[] { "RoomTypeId" });
            DropColumn("dbo.Rooms", "RoomStatusId");
            DropTable("dbo.RoomStatus");
        }
    }
}
