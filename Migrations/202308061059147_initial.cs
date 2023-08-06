namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodCategories",
                c => new
                    {
                        FoodCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.FoodCategoryID);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodID = c.Int(nullable: false, identity: true),
                        FoodCategoryID = c.Int(),
                        Name = c.String(),
                        Image = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Amount = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodID)
                .ForeignKey("dbo.FoodCategories", t => t.FoodCategoryID)
                .Index(t => t.FoodCategoryID);
            
            CreateTable(
                "dbo.MiniOrders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        FoodID = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        ReceiptID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Foods", t => t.FoodID, cascadeDelete: true)
                .ForeignKey("dbo.Receipts", t => t.ReceiptID, cascadeDelete: true)
                .Index(t => t.FoodID)
                .Index(t => t.ReceiptID);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        ReceiptID = c.Int(nullable: false, identity: true),
                        ReceiptDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        CustomerNumber = c.String(),
                        BirunBar = c.Boolean(nullable: false),
                        Confirm = c.Boolean(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReceiptID);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        OfferID = c.Int(nullable: false, identity: true),
                        OfferTitle = c.String(),
                        OfferCode = c.String(),
                        OfferPercent = c.Int(nullable: false),
                        OfferDiscount = c.Int(nullable: false),
                        IsOptional = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OfferID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PriceID = c.Int(nullable: false, identity: true),
                        FoodID = c.Int(nullable: false),
                        PriceValue = c.Int(nullable: false),
                        SetPriceDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PriceID)
                .ForeignKey("dbo.Foods", t => t.FoodID, cascadeDelete: true)
                .Index(t => t.FoodID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleTitle = c.String(),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        UserName = c.String(),
                        FullName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.OfferReceipts",
                c => new
                    {
                        Offer_OfferID = c.Int(nullable: false),
                        Receipt_ReceiptID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Offer_OfferID, t.Receipt_ReceiptID })
                .ForeignKey("dbo.Offers", t => t.Offer_OfferID, cascadeDelete: true)
                .ForeignKey("dbo.Receipts", t => t.Receipt_ReceiptID, cascadeDelete: true)
                .Index(t => t.Offer_OfferID)
                .Index(t => t.Receipt_ReceiptID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Prices", "FoodID", "dbo.Foods");
            DropForeignKey("dbo.OfferReceipts", "Receipt_ReceiptID", "dbo.Receipts");
            DropForeignKey("dbo.OfferReceipts", "Offer_OfferID", "dbo.Offers");
            DropForeignKey("dbo.MiniOrders", "ReceiptID", "dbo.Receipts");
            DropForeignKey("dbo.MiniOrders", "FoodID", "dbo.Foods");
            DropForeignKey("dbo.Foods", "FoodCategoryID", "dbo.FoodCategories");
            DropIndex("dbo.OfferReceipts", new[] { "Receipt_ReceiptID" });
            DropIndex("dbo.OfferReceipts", new[] { "Offer_OfferID" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Prices", new[] { "FoodID" });
            DropIndex("dbo.MiniOrders", new[] { "ReceiptID" });
            DropIndex("dbo.MiniOrders", new[] { "FoodID" });
            DropIndex("dbo.Foods", new[] { "FoodCategoryID" });
            DropTable("dbo.OfferReceipts");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Prices");
            DropTable("dbo.Offers");
            DropTable("dbo.Receipts");
            DropTable("dbo.MiniOrders");
            DropTable("dbo.Foods");
            DropTable("dbo.FoodCategories");
        }
    }
}
