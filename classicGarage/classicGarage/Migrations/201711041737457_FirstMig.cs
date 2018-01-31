namespace classicGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarModels", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Model = c.String(),
                        Year = c.String(),
                        VIN = c.Int(nullable: false),
                        Name = c.String(),
                        PhotoAdress = c.String(),
                        DatePurchase = c.DateTime(nullable: false),
                        DateSale = c.DateTime(nullable: false),
                        PurchasePrice = c.Double(nullable: false),
                        SellingPrice = c.Double(nullable: false),
                        OwnerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OwnerModels", t => t.OwnerID, cascadeDelete: true)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.OwnerModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PartModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        Name = c.String(),
                        CatNumber = c.String(),
                        PurchasePrice = c.Double(nullable: false),
                        SellingPrice = c.Double(nullable: false),
                        DatePurchase = c.DateTime(nullable: false),
                        DateSale = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarModels", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.RepairModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        Name = c.String(),
                        Desciption = c.String(),
                        RepairCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarModels", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RepairModels", "CarID", "dbo.CarModels");
            DropForeignKey("dbo.PartModels", "CarID", "dbo.CarModels");
            DropForeignKey("dbo.AdModels", "CarID", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "OwnerID", "dbo.OwnerModels");
            DropIndex("dbo.RepairModels", new[] { "CarID" });
            DropIndex("dbo.PartModels", new[] { "CarID" });
            DropIndex("dbo.CarModels", new[] { "OwnerID" });
            DropIndex("dbo.AdModels", new[] { "CarID" });
            DropTable("dbo.RepairModels");
            DropTable("dbo.PartModels");
            DropTable("dbo.OwnerModels");
            DropTable("dbo.CarModels");
            DropTable("dbo.AdModels");
        }
    }
}
