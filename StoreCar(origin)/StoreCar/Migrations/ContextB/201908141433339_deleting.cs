namespace StoreCar.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleting : DbMigration
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
                })
                .PrimaryKey(t => t.Id);

            CreateIndex("dbo.CartLines", "Product_Id");
            AddForeignKey("dbo.CartLines", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            
        }
    }
}
