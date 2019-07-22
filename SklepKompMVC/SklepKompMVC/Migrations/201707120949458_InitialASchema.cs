namespace SklepKompMVC.Migrations.MigrationsA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialASchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    CategoryId = c.Int(nullable: false, identity: true),
                    CategoryName = c.String(),
                    CategoryDescription = c.String(),
                    CatIconFileName = c.String(),
                })
                .PrimaryKey(t => t.CategoryId);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    ProductId = c.Int(nullable: false, identity: true),
                    CategoryId = c.Int(nullable: false),
                    ProductName = c.String(),
                    ProductDescription = c.String(),
                    ProducerId = c.Int(nullable: false),
                    DateAdded = c.DateTime(nullable: false),
                    ProductCoverFileName = c.String(),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    IsHidden = c.Boolean(nullable: false),
                    IsBestseller = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Producers", t => t.ProducerId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ProducerId);

            CreateTable(
                "dbo.Producers",
                c => new
                {
                    ProducerId = c.Int(nullable: false, identity: true),
                    ProducerShortName = c.String(),
                    ProducerName = c.String(),
                })
                .PrimaryKey(t => t.ProducerId);

            CreateTable(
                "dbo.OrderItems",
                c => new
                {
                    OrderItemId = c.Int(nullable: false, identity: true),
                    OrderId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                    UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    OrderId = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false),
                    LastName = c.String(nullable: false),
                    Address = c.String(nullable: false),
                    City = c.String(nullable: false),
                    AddresCode = c.String(nullable: false),
                    PhoneNumber = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    Comment = c.String(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                    OrderState = c.Int(nullable: false),
                    TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.OrderId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Products", new[] { "ProducerId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Producers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
