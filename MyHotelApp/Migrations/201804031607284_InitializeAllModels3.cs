namespace MyHotelApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeAllModels3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GuestAccounts", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GuestAccounts", "UserId");
        }
    }
}
