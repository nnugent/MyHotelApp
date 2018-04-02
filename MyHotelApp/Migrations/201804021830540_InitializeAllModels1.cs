namespace MyHotelApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeAllModels1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GuestReservationJunctions", "ReservationId", "dbo.Reservations");
            DropIndex("dbo.GuestReservationJunctions", new[] { "GuestAccountId" });
            DropIndex("dbo.GuestReservationJunctions", new[] { "ReservationId" });
            CreateIndex("dbo.GuestReservationJunctions", "GuestAccountID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.GuestReservationJunctions", new[] { "GuestAccountID" });
            CreateIndex("dbo.GuestReservationJunctions", "ReservationId");
            CreateIndex("dbo.GuestReservationJunctions", "GuestAccountId");
            AddForeignKey("dbo.GuestReservationJunctions", "ReservationId", "dbo.Reservations", "Id", cascadeDelete: true);
        }
    }
}
