namespace gellmvc.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderedProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        QtyToOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        OrderStatus = c.String(nullable: false, maxLength: 25),
                        ShippingAddressId = c.Int(),
                        BillingAddressId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAddresses", t => t.BillingAddressId)
                .ForeignKey("dbo.UserAddresses", t => t.ShippingAddressId)
                .Index(t => t.ShippingAddressId)
                .Index(t => t.BillingAddressId);
            
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        Line1 = c.String(nullable: false, maxLength: 50),
                        Line2 = c.String(maxLength: 50),
                        City = c.String(nullable: false, maxLength: 25),
                        State = c.String(nullable: false, maxLength: 25),
                        PostCode = c.String(nullable: false, maxLength: 25),
                        CountryOrRegion = c.String(nullable: false, maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ImageUrl = c.String(),
                        Description = c.String(maxLength: 250),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostFromSupplier = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityInStock = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderedProducts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ShippingAddressId", "dbo.UserAddresses");
            DropForeignKey("dbo.Orders", "BillingAddressId", "dbo.UserAddresses");
            DropIndex("dbo.Orders", new[] { "BillingAddressId" });
            DropIndex("dbo.Orders", new[] { "ShippingAddressId" });
            DropIndex("dbo.OrderedProducts", new[] { "ProductId" });
            DropIndex("dbo.OrderedProducts", new[] { "OrderId" });
            DropTable("dbo.Products");
            DropTable("dbo.UserAddresses");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderedProducts");
        }
    }
}
