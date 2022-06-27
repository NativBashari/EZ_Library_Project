namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Products", "Title", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Products", "Author", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Products", "Publishing", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Publishing", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
        }
    }
}
