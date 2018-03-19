namespace Product_Server.Migrations.ProductMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialProductMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        ReorderLevel = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        SupplierID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Supplier", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Supplier");
            DropIndex("dbo.Products", new[] { "SupplierID" });
            DropTable("dbo.Supplier");
            DropTable("dbo.Products");
        }
    }
}
