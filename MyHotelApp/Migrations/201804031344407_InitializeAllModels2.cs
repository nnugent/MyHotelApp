namespace MyHotelApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeAllModels2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotelInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        StateId = c.Int(nullable: false),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HotelInfoes", "StateId", "dbo.States");
            DropIndex("dbo.HotelInfoes", new[] { "StateId" });
            DropTable("dbo.HotelInfoes");
        }
    }
}
