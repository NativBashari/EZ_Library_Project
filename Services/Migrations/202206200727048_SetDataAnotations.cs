namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDataAnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Costumer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Product_Id", "dbo.Products");
            DropIndex("dbo.Rentals", new[] { "Costumer_Id" });
            DropIndex("dbo.Rentals", new[] { "Product_Id" });
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Rentals", "Costumer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Rentals", "Product_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Publishing", c => c.String(nullable: false));
            CreateIndex("dbo.Rentals", "Costumer_Id");
            CreateIndex("dbo.Rentals", "Product_Id");
            AddForeignKey("dbo.Rentals", "Costumer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Rentals", "Costumer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Product_Id" });
            DropIndex("dbo.Rentals", new[] { "Costumer_Id" });
            AlterColumn("dbo.Products", "Publishing", c => c.String());
            AlterColumn("dbo.Products", "Author", c => c.String());
            AlterColumn("dbo.Products", "Title", c => c.String());
            AlterColumn("dbo.Rentals", "Product_Id", c => c.Int());
            AlterColumn("dbo.Rentals", "Costumer_Id", c => c.Int());
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            CreateIndex("dbo.Rentals", "Product_Id");
            CreateIndex("dbo.Rentals", "Costumer_Id");
            AddForeignKey("dbo.Rentals", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Rentals", "Costumer_Id", "dbo.Customers", "Id");
        }
    }
}
