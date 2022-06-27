namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                        Costumer_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Costumer_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Costumer_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        Title = c.String(),
                        Author = c.String(),
                        Publishing = c.String(),
                        Price = c.Double(nullable: false),
                        RentPrice = c.Double(nullable: false),
                        Availability = c.Int(nullable: false),
                        PublishDate = c.DateTime(),
                        Genre = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Rentals", "Costumer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Product_Id" });
            DropIndex("dbo.Rentals", new[] { "Costumer_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Rentals");
            DropTable("dbo.Customers");
        }
    }
}
