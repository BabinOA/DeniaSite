namespace DeniaRealty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientModels",
                c => new
                    {
                        ClientModelId = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                        EMail = c.String(),
                        Phone = c.String(),
                        Skype = c.String(),
                    })
                .PrimaryKey(t => t.ClientModelId);
            
            CreateTable(
                "dbo.PhotoRealtyRents",
                c => new
                    {
                        PhotoRealtyRentId = c.Int(nullable: false, identity: true),
                        PhotoType = c.String(),
                        PhotoData = c.Binary(),
                        RealtyRentModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoRealtyRentId)
                .ForeignKey("dbo.RealtyRentModels", t => t.RealtyRentModelId, cascadeDelete: true)
                .Index(t => t.RealtyRentModelId);
            
            CreateTable(
                "dbo.PhotoRealtySells",
                c => new
                    {
                        PhotoRealtySellsId = c.Int(nullable: false, identity: true),
                        PhotoType = c.String(),
                        PhotoData = c.Binary(),
                        RealtySellsModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoRealtySellsId)
                .ForeignKey("dbo.RealtySellsModels", t => t.RealtySellsModelId, cascadeDelete: true)
                .Index(t => t.RealtySellsModelId);
            
            CreateTable(
                "dbo.RealtyRentModels",
                c => new
                    {
                        RealtyRentModelId = c.Int(nullable: false, identity: true),
                        Area = c.String(),
                        Type = c.String(),
                        RoomsQuantity = c.String(),
                        Square = c.Double(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RealtyRentModelId);
            
            CreateTable(
                "dbo.RealtySellsModels",
                c => new
                    {
                        RealtySellsModelId = c.Int(nullable: false, identity: true),
                        Area = c.String(),
                        Type = c.String(),
                        RoomsQuantity = c.String(),
                        Square = c.Double(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RealtySellsModelId);
            
            CreateTable(
                "dbo.ServicesModels",
                c => new
                    {
                        ServicesModelId = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ServicesModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhotoRealtySells", "RealtySellsModelId", "dbo.RealtySellsModels");
            DropForeignKey("dbo.PhotoRealtyRents", "RealtyRentModelId", "dbo.RealtyRentModels");
            DropIndex("dbo.PhotoRealtySells", new[] { "RealtySellsModelId" });
            DropIndex("dbo.PhotoRealtyRents", new[] { "RealtyRentModelId" });
            DropTable("dbo.ServicesModels");
            DropTable("dbo.RealtySellsModels");
            DropTable("dbo.RealtyRentModels");
            DropTable("dbo.PhotoRealtySells");
            DropTable("dbo.PhotoRealtyRents");
            DropTable("dbo.ClientModels");
        }
    }
}
