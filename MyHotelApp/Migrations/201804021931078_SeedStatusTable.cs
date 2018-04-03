namespace MyHotelApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedStatusTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RoomStatus (StatusName) VALUES ('clean')");
            Sql("INSERT INTO RoomStatus (StatusName) VALUES ('dirty')");
            Sql("INSERT INTO RoomStatus (StatusName) VALUES ('occupied')");
        }
        
        public override void Down()
        {
        }
    }
}
