namespace MyHotelApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeAllModels4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoomTypes", "Cost", c => c.Double(nullable: false));

        }

        public override void Down()
        {
            DropColumn("dbo.RoomTypes", "Cost");
          
        }
    }
}
