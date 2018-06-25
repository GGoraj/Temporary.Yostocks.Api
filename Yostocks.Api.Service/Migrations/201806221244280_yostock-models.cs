namespace Yostocks.Api.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yostockmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fragments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockId = c.Int(nullable: false),
                        YostocksUserId = c.Int(nullable: false),
                        PercentValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stocks", t => t.StockId, cascadeDelete: true)
                .ForeignKey("dbo.YostocksUsers", t => t.YostocksUserId, cascadeDelete: true)
                .Index(t => t.StockId)
                .Index(t => t.YostocksUserId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false),
                        RemainingPercentage = c.Double(nullable: false),
                        PriceWhenPurchased = c.Double(nullable: false),
                        DateGenerated = c.String(nullable: false),
                        TimeGenerated = c.String(nullable: false),
                        LogoImagePath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.YostocksUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 15),
                        Email = c.String(),
                        Phone = c.String(nullable: false),
                        City = c.String(),
                        Country = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fragments", "YostocksUserId", "dbo.YostocksUsers");
            DropForeignKey("dbo.Fragments", "StockId", "dbo.Stocks");
            DropIndex("dbo.Fragments", new[] { "YostocksUserId" });
            DropIndex("dbo.Fragments", new[] { "StockId" });
            DropTable("dbo.YostocksUsers");
            DropTable("dbo.Stocks");
            DropTable("dbo.Fragments");
        }
    }
}
