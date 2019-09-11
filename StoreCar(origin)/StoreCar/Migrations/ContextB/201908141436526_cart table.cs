namespace StoreCar.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(),
                        Quantity = c.Int(nullable: false),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Cart_Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartLines", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.CartLines", "Product_Id", "dbo.Products");
            DropIndex("dbo.CartLines", new[] { "Cart_Id" });
            DropIndex("dbo.CartLines", new[] { "Product_Id" });
            DropTable("dbo.Carts");
            DropTable("dbo.CartLines");
        }
    }
}
